$(document).ready(function () {
    $('#add-product-button').click(function () {
        var productId = $('#prescripted-product-select').val();
        var productName = $('#prescripted-product-select option:selected').text();
        var quantity = $('#product-quantity-input').val();

        if (productId && productName && quantity) {
            var productHtml = '<div class="product-item">' +
                '<input type="hidden" name="PrescriptedProducts.Index" value="-1" />' +
                '<input type="hidden" name="PrescriptedProducts[0].Product.ID" value="' + productId + '" />' +
                '<input type="hidden" name="PrescriptedProducts[0].Product.ProductName" value="' + productName + '" />' +
                '<span class="product-name">' + productName + '</span>' +
                '<button type="button" class="remove-product-button">Remove</button>' +
                '</div>';

            $('#prescripted-product-list').append(productHtml);
            $('#product-quantity-input').val('');
        }
    });

    $(document).on('click', '.remove-product-button', function () {
        $(this).parent().remove();
    });
});