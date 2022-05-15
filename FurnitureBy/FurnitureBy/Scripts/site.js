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