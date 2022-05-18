$(function () {
    //$(".selectpicker").selectpicker();
});

function AddToBasket(code)
{
    $.ajax({
        async: true,
        type: 'post',
        url: '/Order/AddToBasket',
        data: {
            "productCode": code
        },
        success: function (result)
        {
            if (result) {
                alert('Товар добавлен в корзину');
            }
            else
            {
                alert('Товар уже есть в корзине');
            }
        }
    });
}

function ChangePassword(login, newPassword, confirmNewPassword) {
    $.ajax({
        async: true,
        type: 'post',
        url: '/User/ChangePassword',
        data: {
            "login": login,
            "password": newPassword,
            "confirmPassword": confirmNewPassword
        },
        success: function (data) {
            if (data.result) {
                alert('Пароль успешно изменен');
            }
            else {
                alert(data.message);
            }
        }
    });
}