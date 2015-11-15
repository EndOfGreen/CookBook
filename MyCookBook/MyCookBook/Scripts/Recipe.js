
var cookStepModel=
    {
        RecipeId : 0,
        Name :'',
        Author :'',
        Private : false,
        ImageLink :  '',
        CookTime : 0,
        CuisineId : 0,
        Volume: 0,
        CathegoryId: new Array(),
        Ingridients : new Array(),
        Steps : new Array(),
    };
ko.applyBindings(cookStepModel);


function save(){
    $.ajax({
        url: "Create",
        type: "post",
        contentType: "application/json",
        data: ko.mapping.toJSON(cookStepModel)
    })
};