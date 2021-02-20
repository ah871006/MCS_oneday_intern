// 幫購買按鍵加入點擊的所需的function
function onBuyClick(productId, inventory) {
    // 購買時所要call的action
    let buyUrl = $("#buyUrl").data('request-url');

    // 購買數量
    let num = parseInt($("#buyQuantity").val());

    let inventoryNum = parseInt(inventory);

    // 將購買數量及產品Id包裝成一個物件
    let arg = {
        productNumber: productId,
        quantity: num,
        inventory: inventoryNum - num,
    }

    // 若存貨小於購買數量則購買失敗
    if (num > inventoryNum) {
        alert("購買數量超出庫存請重新選擇");
        return;
    }

    // 加分題
    $.ajax({
        method: 'POST',
        url: 'http://140.112.251.124:51113/Home/GetProductData',
        dataType: 'json',
        data: arg,
        success: function(data) {
            console.log(data);
        }
    });

    // 使用post來call controller中的購買action
    $.post(buyUrl, arg, (data) => {
        console.log(data);
        alert("扣庫成功 - 已購買數量:" + String(data.deductionQuantity));
        window.location.reload();
    })
}

// 點擊預覽圖片時變更大圖
function onClickImage(imageUrl) {
    // 更新圖片
    $("#banner").attr("src", imageUrl);
}

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