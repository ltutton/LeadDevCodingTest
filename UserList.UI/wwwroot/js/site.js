// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
(function() {
    var apiHostname = 'http://localhost:5001/User';
    var app = new Vue({
        el: '#app',
        data: {
            searchTerm: "",
            loading: true,
            error: false,
            userList: [{
                firstName: null,
                familyName: null,
                username: null
            }]
        },
        created: function() {
            var vue = this;
            $.ajax({
                url: apiHostname,
                crossDomain: true,
                dataType: 'json',
                method: 'GET',
                success: function(data) {
                    vue.userList = data;
                    vue.loading = false;
                    vue.error = false;
                },
                error: function(data) {
                    vue.error = true;
                    vue.loading = false;
                }
            });
        },
        methods: {
            search: function(event) {
                var vue = this;
                if (!vue.loading) {
                    vue.loading = true;
                    $.ajax({
                        url: apiHostname + '/Search',
                        data: {
                            familyName: vue.searchTerm
                        },
                        dataType: "json",
                        success: function(data) {
                            vue.userList = data;
                            vue.loading = false;
                            vue.error = false;
                        },
                        error: function(data) {
                            vue.error = true;
                            vue.loading = false;
                        }
                    
                    });
                }
            }
        }
    });
})();
