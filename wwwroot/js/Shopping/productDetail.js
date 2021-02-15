// 當購買數量有變化時更新購買總價格
function updateInput(unitPrice) {
    // 購買數量
    let buyNums = $("#buyQuantity").val();

    // 總價格
    let totalPrice = buyNums * unitPrice

    // 更新總價格
    $("#price").text("總價格 $" + String(totalPrice))
}

// 提交新的商品評價
function onReviewSubmit() {
    // 評價者名稱
    let reviewer = $("#reviewer").val();

    // 評價者信箱
    let reviewerEmail = $("#reviewerEmail").val();

    // 評價內容
    let reviewContent = $("#reviewContent").val();

    // // 提交評價時所要call的action
    let commentUrl = $("#reviewPoster").data('request-url');
    console.log(commentUrl);

    // 將評價相關資訊包成一個物件
    let arg = {
        Reviewer: reviewer,
        ReviewerEmail: reviewerEmail,
        ReviewContent: reviewContent
    }

    // 使用post來call controller中的評價action
    $.post(commentUrl, arg, (data) => {
        console.log(data);
        window.location.reload();
    })
}