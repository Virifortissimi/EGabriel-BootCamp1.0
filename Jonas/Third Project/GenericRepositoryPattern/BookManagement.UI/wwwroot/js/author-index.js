(function ($) {
    function Author() {
        var $this = this;

        function initilizeModel() {
            $("#addAuthor").on('loaded.bs.modal', function (e) { }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
            $("#addBook").on('loaded.bs.modal', function (e) { }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Author();
        self.init();
    })
}(jQuery))