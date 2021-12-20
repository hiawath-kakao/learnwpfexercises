
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Dynamic;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace WpfApp1
{
    [CheckUser]
    public class MypageController
    {

        private readonly ILogger _logger;

        public MypageController(ILogger<MypageController> logger)
        {
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Mypage()
        {
            return NotFound();
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MypageUserRemove()
        {
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return NotFound();
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
