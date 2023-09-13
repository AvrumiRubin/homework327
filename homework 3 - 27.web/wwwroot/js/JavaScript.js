$( () => {
    let num = 1;

    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div class="row">
            <div class="bg-light rounded-3 p-5 mt-3">
                <div class="col-md-6 offset-md-3">
                    <input type="text" name="peoples[${num}].firstname" class="form-control" placeholder="First Name" />
                </div>
                <div class="col-md-6 offset-md-3 mt-3">
                    <input type="text" name="peoples[${num}].lastname" class="form-control" placeholder="Last Name" />
                </div>
                <div class="col-md-6 offset-md-3 mt-3">
                    <input type="text" name="peoples[${num}].age" class="form-control" placeholder="Age" />
                </div>
            </div>
        </div>`)
        num++;
    })


})
