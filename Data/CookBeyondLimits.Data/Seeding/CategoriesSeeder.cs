namespace CookBeyondLimits.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookBeyondLimits.Services.Data.Categories;

    using Microsoft.Extensions.DependencyInjection;

    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categoryService = serviceProvider.GetRequiredService<ICategoriesService>();

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Breakfast & Brunch", "https://previews.dropbox.com/p/thumb/AAxd4_2mY4RxlPQa8zy0N1eg40FwOxh40KrTd6gv8iJoItQgoKGvwjd_8c6PMHOa5dfKx1qslcM0WJOwaROnQRLN6QXHyeij5p7vFkKIeuOBokqPFt1lxxN0CcWZ7QcYI-3MRvQ1Z6k9o5i1CYAtmJNRPQCG_QnkGGxZIzQw7ZCBfw9E1QorrwIX68QbfnK-hEFnJ4yF80O2qo1ko7ghq4nvkPhnCx78VvNOllaTU2J1OqmR21MRbtK5Jx8kUXFYlgFtiT6j5ZEKAmtBY5e_wmCrMB82iuLWTLJUYWGLCxmgBNZ9NIUwAKNVPv6SjWPCpxgZCH8IrQl6REAHhdnfkSA_/p.jpeg?fv_content=true&size_mode=5"),
                ("Appetizers & Snacks", "https://previews.dropbox.com/p/thumb/AAz6jxOYp4tShw7dHPJ4qizWSgVffMZxH4oOzUds0Dg4SrvKMH5ZcY-6kEXZWz1a3AKo81AMmfstqEjqAC4kkmU3L5FJKxuMvscwkyaEyF7AxLaHHjVjWhzhQ_QfxpkwdLoGHsBMzKio0DFbZrzNYvTzg0HiXBNIakhG6c2UH32sFFb_er1vYPqRvka0fNTz_4DALPCb9sHr1zuTwiYJVFfVxTQ-AS5TY6FtoDFMSCZzqqXzEUmuNMew1Wpl0CxLg4ZBvpVx9JK6XLj9a27bh6XqzswniPxvBuqmLba4oAbGr_UfVjmZf29BE4b6cwv3Nz5vZ7cVmOGVGtEr4ZKBKDWKLJWBSw_yj8JouFbO4S_XqQ/p.jpeg?fv_content=true&size_mode=5"),
                ("Salads", "https://previews.dropbox.com/p/thumb/AAy57L_b1BANHR1_PbBqzCS0K7gr_JoGo49NUDRbPikjAyrSS3WvAYIFgpC9nVckZurKQvveQ8z2oy6Yd3FE299kAg87U6ANJmOehkgeNN-LaJO8DqOH15bKicL1a0gMuW75TZIZ_nzY7fWEMaUGhyOlxkvsOVyePsAiuz5qOVhF44njVjJp8ngV1MEdRnBb2JbU6LHNA41GdAUZzUikuWHU7TTbkGyjItDIpLCrudflDFCFOAyHkjrV1mJHHh8uUKjuEhHwy2u0fOQe-i27axKe-4lxXlwMfBEBUtUrI4qQVrgwfmEwBQSFlddyNBx_IdQ13rzVnGP29FSy9KF_GVMKehRGfwigbi7TFMvXDDUpsQ/p.jpeg?fv_content=true&size_mode=5"),
                ("Soups", "https://previews.dropbox.com/p/thumb/AAwNHijOX5rjXcp0l2V-VHxU_NQ0y-GrrSUeoNO_AmIaWqh6bx2Jdgsh-7sU-TzfRTk7Gm9_ce4hWujtlrDWPQPqvLEmuiAScJ5VeHK88L4OMsvg0YypalbXRYBq4gR02-d0YckaI7eyoxDn3Avbg7Fv_Tcwo0vuy38Zi7irm9n1BP9zy0b5pImwKfeJKBIJyXb-hOaZqGBhx1rAXNTUlETRHYhlF9hPkr7Fqjaj2UpGVo9_iLzT8lu7iQ8G-zEvQpFge3KbIArzzG2O14ZCyv5AzCRFYHFT-DTLARfoXE3MAu8WtKL33CdAZd_YevFpEK8DwsDveGhkIDJgA_r2NKMYaz1ya4ayQwFb3NTLZlk8qA/p.jpeg?fv_content=true&size_mode=5"),
                ("Main Dishes", "https://previews.dropbox.com/p/thumb/AAwg9tE2eYftrznxnk1jYcUTzDYhfr8LcggItvYlyIAqz-FREOpIi2AiYVMDunGyyAvJXR0r6pxfFtOI8mrNdG-vIBgnKXOCjtdYPh1ZnxQATf92V1Z9vBZNqC6PPM5EN5iFakMqeQc2NK1RtACKKNwBd9aBjG43Nv47NsHwylX4j42O2O5Gt5fW1xTX93IkRQI8sbY3qpn7HPQ_uypqscj_QdXDGqAwlclqAkjRyGHp57F4P2FTIJipYUvc1PNL5NqEAXhD48l00vcJ45vRm1SlTwxVb4-quS2vZhoCu-YdF8vTiGSoaJrkemdlBotLOB2sqbIznzJSrXUNhJ9a3zLYYgxfZLkYE5RyJcOPB192_w/p.jpeg?fv_content=true&size_mode=5"),
                ("Side Dishes", "https://previews.dropbox.com/p/thumb/AAx-nSOVlPjnZ5YjDL3tXrgWLhYjrNw3Rk--vEEqIgjj7llb2Kr9RmBaqOqgYqQRUPV_JN3oQ0wKUHQZKFuIreYjvawvESncSPm9JspLXQKADKtnF5OD538khlxXdEnBhdTOQQc_fowAy4lCunRQA_gTbGp21ZAL74jEv_ZtD27WqllGhfVl2wcbBQGpECI-duGQUWR_JNMXX0eDtXw_3Aq_h0peamOM3d4kuFCgdgdhXeqIbeOaSuNu3Zg6zWmBwo19iuuNdLMO9pypxm_mnGpkX1m4o9-wnC3XJ68nVQ7pd4K2r9aJs37jDyNZBXGkZw3U1b6ikerl9s77anXCCNQ_4uFa7XjxB0iGCvouNcwvig/p.jpeg?fv_content=true&size_mode=5"),
                ("Desserts", "https://previews.dropbox.com/p/thumb/AAzn-M91dNMoYVUnbNn-ec_ytRsJJGNf1Mvbn2wlMxPPyjS_8nTjVsgkFpe0GMcwWGBq2PBBgfmvqGTmXnLRG2Cz2aw-vHEw6P2Y1Nyl02ucqmZsfFTpdwD8imNkJc_p-FAjkmBb0k7mbvv_OhomGmR43T0mFIxLWir3hNuUkAANk1sDoh91mgTTAzi4ocjOBQ6wKdZZnSMJ-vLyC6NxkJfxKQB8QPN64dKPNPR-ifIrpx2hHymExlBby6aY5npWb98v3Mlt-dXzz_sWiZ51zYF30VWJo57KGBuNT5IlzWtBbotBy32pseYFGpxqY2HKWyxMIZiI24c4uEgSrZeYqEhSKp3CbZNT8Cq75oDz52yv3g/p.jpeg?fv_content=true&size_mode=5"),
                ("Sauces & Dressings", "https://previews.dropbox.com/p/thumb/AAz4A6XDIH8oKDncgZRUcdvAV3a2-dxgZ2Qu4KR40QZf7dtSGgQSj0ohmXaXeSfetrlpEGOyIbfnLO2t54uBS6lAy0q0eYUyWOVYlDb9CTDqEpwCZOcLk0Irpf5LIbqtaDMpxwd_tIcRUeulnFzlfS44FfnaW0uoS21j1yoSET4YHRsxqEqxb2iuhrhfcbKma6Y0qqnyhXLmxCte9GNRnxyGrouslqonVBOq3CztlFGBOod3a6OGyyy7Lko1T9WEBijB2_n8j-Wnb-g5Nj4LtyIm2Up_9NrlqJ13xz-kqqqADBW5nQkKBld3nze5sjTyZ_RrM0AxzgHAk7gyWRqZMxKGXomgibpPA18aHXubWB1MEA/p.jpeg?fv_content=true&size_mode=5"),
                ("Drinks", "https://previews.dropbox.com/p/thumb/AAwp76O5dNLOOjv7vkAxC4Kzw4R4I4Sate2r-V0qRiAaCxppAehkDhT851MbV9hNkOjV2W3Ve88LYfkIpKfUYcC8OMS_aq10WvoqnEWwNt4zBrnVFUR2EZ1Ov-lYjrZfsln3eSNmjPtmSPga4MELwcuAfhUGFO_dsV5ebZKjb31gLaPXpamxaBfQwvLSRFlQNgSwWurU3Frcn1xq9Y21_DlSc5pCmMu9Ey0fpvnFvSFF7IRi7w_YGR5IxKVdJy4rPwMh-MQQOvRcqe-GSTyCU1GeSBIAEtd0r7jLwKNzpdudkNpXT9INyxnsnsPi2QFuga8Xl2z_izG1_Rq57Jd0nVIYRmb1O2TYCwPgqy6S-LmPfg/p.jpeg?fv_content=true&size_mode=5"),
            };

            await categoryService.CreateAllAsync(categories);
        }
    }
}
