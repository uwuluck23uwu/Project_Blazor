redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51P8zpUJDEspePZjo73Y0CF0vnLNm4em25JMvdXDYvGxCpUC5YL0CHTcTvx5Mo93MiKlzaWJIYUUmgCnGf6J2nH2M00DAUzDZYs");
    stripe.redirectToCheckout({ sessionId: sessionId });
}
