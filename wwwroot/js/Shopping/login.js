function LoginViewModel(urldict) {
    var self = this;
    self.test = function(){
        console.log("login clicked");
        $.post(urldict.login, { accountName: "test", password: "test" }, (data) => {
            console.log(data);
        });
    };
}
