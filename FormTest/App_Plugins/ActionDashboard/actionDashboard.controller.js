angular.module("umbraco").controller("ActionDashboardController", function ($scope, userService, contentResource, editorService) {

    var vm = this;

    // partners id
    const PARENT_NODE = 1156;

    // userservice.getCurrentUser() returns current logged in user
    userService.getCurrentUser()
        .then(user => {
            // check if current user in editors group is allowed to have access to dashboard
            // if(user == "permittedUser")
            contentResource.getChildren(PARENT_NODE)
                .then(partner => {

                    // filter partners that dont have "Aktionen"
                    let filterdPartners = partner.items.filter(partner => {
                        for (let prop of partner.properties) {
                            // TODO find better way to check if "Aktion" has a value
                            if (prop.alias == "aktionen" && prop.value != "") {
                                return prop;
                            }
                        }
                    })
                    // bind filtered Partners to view
                    vm.Partners = filterdPartners;
                })
        });

    // bind function to view
    vm.open = OpenActionDetail

    function OpenActionDetail(partnerData) {
        var options = {
            title: "Aktionen von: " + partnerData.name,
            view: "/App_Plugins/ActionDashboard/Dialogs/action.dialog.html",
            size: "medium",
            partner: partnerData.properties,
            submit: function (event) {
                //console.log("event:", event);
                editorService.close();
            },
            close: function () {
                editorService.close();
            }
        };
        editorService.open(options);
    }

});