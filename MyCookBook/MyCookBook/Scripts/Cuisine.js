function Post(url) {
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'JSON',
        data: { '' : ko.mapping.toJSON(cuisineViewModel)},
        success: function (success)
        {
            if (success) alert('Успешно сохранено!');
            else alert('Не сохранено!');
        }
    })
};

function Get(url) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'JSON',
        data : {id : 1},
        success: function (data) {
            if (success) alert('data');
            else alert('Не сохранено!');
        }
    })
};

function Put(url) {
    $.ajax({
        url: url,
        type: 'PUT',
        data: {'':ko.mapping.toJSON(cuisineViewModel)},
        success: function (success) {
            if (success) alert('Успешно сохранено!');
            else alert('Не сохранено!');
        }
    })
};

function Delete(CuisineId) {
    if (confirm("Точно хотите удалить?")) {
        $.ajax({
            url: 'api/Cuisine/DeleteCuisine',
            type: 'DELETE',
            data: { '': CuisineId },
            success: function (success) {
                if (success) {
                    $("." + success).remove();
                    alert('Успешно удалено!');
                }
                else alert('Ошибка при удалении!');
            }
        })
    }
};



function ImageFilePost(input,url,output) {
    var formData = new FormData();
    var file = document.getElementById(input).files[0];
    formData.append(input, file);
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            $(".thumb").remove();
            $('#' + output).html(['<img class="thumb" src="', data, '"/>'].join(''));
            cuisineViewModel.ImageLink = data;
        }
    });
};


function Back()
{ history.back(); };

function Redirect(url)
{
    window.location.href = url;
};