.class public Lcom/igg/sdk/payment/google/IGGPaymentActivityBase;
.super Landroid/app/Activity;
.source "IGGPaymentActivityBase.java"


# instance fields
.field protected paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 14
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V

    return-void
.end method


# virtual methods
.method protected onActivityResult(IILandroid/content/Intent;)V
    .locals 2
    .param p1, "requestCode"    # I
    .param p2, "resultCode"    # I
    .param p3, "data"    # Landroid/content/Intent;

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentActivityBase;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 26
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentActivityBase;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/IGGPayment;->getIABHelper()Lcom/google/payment/IabHelper;

    move-result-object v0

    invoke-virtual {v0, p1, p2, p3}, Lcom/google/payment/IabHelper;->handleActivityResult(IILandroid/content/Intent;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 27
    invoke-super {p0, p1, p2, p3}, Landroid/app/Activity;->onActivityResult(IILandroid/content/Intent;)V

    .line 33
    :cond_0
    :goto_0
    return-void

    .line 30
    :cond_1
    const-string v0, "onActivityResult"

    const-string v1, "onActivityResult"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 31
    invoke-super {p0, p1, p2, p3}, Landroid/app/Activity;->onActivityResult(IILandroid/content/Intent;)V

    goto :goto_0
.end method
