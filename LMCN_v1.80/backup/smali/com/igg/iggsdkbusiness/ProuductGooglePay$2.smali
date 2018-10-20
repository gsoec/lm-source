.class Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;
.super Ljava/lang/Object;
.source "ProuductGooglePay.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getProduct()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/ProuductGooglePay;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    .prologue
    .line 164
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onIGGPurchaseFailed(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;Lcom/google/payment/Purchase;)V
    .locals 3
    .param p1, "type"    # Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;
    .param p2, "purchase"    # Lcom/google/payment/Purchase;

    .prologue
    .line 254
    sget-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IGG_GATEWAY:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    if-ne p1, v0, :cond_0

    .line 255
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payGatewayFailedCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->PaymentSuccessful:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 264
    :goto_0
    return-void

    .line 257
    :cond_0
    sget-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_PURCHASE:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    if-ne p1, v0, :cond_1

    .line 259
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payFailedCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->ErrorPaymentFailed:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 260
    :cond_1
    sget-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_CANCELED:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    if-ne p1, v0, :cond_2

    .line 261
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payCancelCallBack()V

    goto :goto_0

    .line 263
    :cond_2
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payFailedCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->ErrorPaymentFailed:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method public onIGGPurchaseFinished(Lcom/google/payment/Purchase;Ljava/lang/Boolean;)V
    .locals 3
    .param p1, "purchase"    # Lcom/google/payment/Purchase;
    .param p2, "isSendComplete"    # Ljava/lang/Boolean;

    .prologue
    .line 242
    invoke-virtual {p2}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 247
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paySuccessCallBack:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 249
    return-void
.end method

.method public onIGGPurchasePreparingFinished(ZLjava/lang/String;)V
    .locals 4
    .param p1, "success"    # Z
    .param p2, "error"    # Ljava/lang/String;

    .prologue
    const/4 v3, 0x1

    .line 169
    const-string v0, "ProuductGooglePay"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onIGGPurchasePreparingFinished with "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {p1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 171
    if-nez p1, :cond_0

    .line 174
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    const-string v1, "android"

    const/4 v2, 0x0

    new-instance v3, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$1;

    invoke-direct {v3, p0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$1;-><init>(Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;)V

    invoke-virtual {v0, v1, v2, v3}, Lcom/igg/sdk/payment/google/IGGPayment;->loadItems(Ljava/lang/String;ZLcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z

    .line 193
    const-string v0, "ProuductGooglePay"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onIGGPurchasePreparingFinished error: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 228
    :goto_0
    return-void

    .line 197
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    invoke-static {v0, v3}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->access$102(Lcom/igg/iggsdkbusiness/ProuductGooglePay;Z)Z

    .line 199
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    const-string v1, "android"

    new-instance v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;-><init>(Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;)V

    invoke-virtual {v0, v1, v3, v2}, Lcom/igg/sdk/payment/google/IGGPayment;->loadItems(Ljava/lang/String;ZLcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z

    goto :goto_0
.end method

.method public onIGGPurchaseStartingFinished(Z)V
    .locals 3
    .param p1, "success"    # Z

    .prologue
    .line 232
    if-nez p1, :cond_0

    .line 233
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->purchaseStartingFailedCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->ErrorPaymentIsNotReady:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 236
    :cond_0
    return-void
.end method
