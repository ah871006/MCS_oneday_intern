function updateInput(unitPrice) {
    let buyNums = $("#buy_quantity").val();
    let totalPrice = buyNums * unitPrice
    $("#price").text("總價格 $" + String(totalPrice))
}

function onReviewSubmit() {
    let reviewer = $("#reviewer").val();
    let reviewerEmail = $("#reviewerEmail").val();
    let reviewContent = $("#reviewContent").val();
    let commentUrl = $("#reviewPoster").data('request-url');
    console.log(commentUrl);
    let arg = {
        Reviewer: reviewer,
        ReviewerEmail: reviewerEmail,
        ReviewContent: reviewContent
    }
    $.post(commentUrl, arg, (data) => {
        console.log(data);
        window.location.reload();
    })
}