$(document).ready(function () {

    $('a.btn.btn-sm.btn-danger').click(function () {
        return confirm("This opperation cannot be undone! Are you sure you want to continue?");
    });

});