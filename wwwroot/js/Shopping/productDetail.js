function updateInput(unitPrice) {
    let buyNums = $("#buy_quantity").val();
    let totalPrice = buyNums * unitPrice
    $("#price").text("價格$ " + String(totalPrice))
}