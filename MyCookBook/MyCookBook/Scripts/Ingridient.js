﻿function Post(url) {
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'JSON',
        data: { '': ko.mapping.toJSON(viewModel) },
        success: function (success)
        {
            if (success) alert('Успешно сохранено!');
            else alert('Не сохранено!');
        }
    })
};

function Put(url) {
    $.ajax({
        url: url,
        type: 'PUT',
        data: { '': ko.mapping.toJSON(viewModel) },
        success: function (success) {
            if (success) alert('Успешно сохранено!');
            else alert('Не сохранено!');
        }
    })
};

function Delete(ingridientId) {
    if (confirm("Точно хотите удалить?")) {
        $.ajax({
            url: 'api/Ingridient/DeleteIngridient',
            type: 'DELETE',
            data: { '': ingridientId},
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



