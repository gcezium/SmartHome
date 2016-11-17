using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Cezium.SmartHome.UI.Models.VM.Accounts
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        private string _backgroundImage = String.Empty;
        public string BackgroundImage {  get { return _backgroundImage; } }

        public LoginViewModel()
        {
            string imagesDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "content\\img\\loginBg");
            string[] imageFiles = Directory.GetFiles(imagesDirectoryPath);

            if (imageFiles.Length > 0)
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                string filename = Path.GetFileName(imageFiles[rnd.Next(0, imageFiles.Length - 1)]);
                _backgroundImage = "/content/img/loginbg/" + filename;
            }
        }
    }
}