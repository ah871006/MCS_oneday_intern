function IndexViewModel(urldict) {
    var self = this;
    self.GotoProduct = (num) => {
        window.location = "/ProductDetail/Index/?ProductNumber=" + num;
    }
}