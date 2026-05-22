(function () {
  const cards = document.querySelectorAll(".product-card");

  const navigateToDetails = (productId) => {
    if (!productId) {
      return;
    }

    window.location.assign(`/products/${productId}`);
  };

  cards.forEach((card) => {
    card.addEventListener("click", () => {
      navigateToDetails(card.dataset.productId);
    });

    card.addEventListener("keydown", (event) => {
      if (event.key === "Enter" || event.key === " ") {
        event.preventDefault();
        navigateToDetails(card.dataset.productId);
      }
    });
  });
})();
