using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

function showPassword() {
    const password = document.querySelector('#Password');
    var num = 1;
    password.type = (password.type === "password") ? "text" : "password";
    console.log(num)
}
