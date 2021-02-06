function IndexViewModel(urldict) {
    var self = this;
    self.GotoProduct = (num) => {
        window.location = "/ProductDetailControllor/Index/?ProductNumber=" + num;
    }
}