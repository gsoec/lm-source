.class Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;
.super Ljava/lang/Object;
.source "ProuductGooglePay.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->onIGGPurchasePreparingFinished(ZLjava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    .prologue
    .line 199
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;->this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoadCachePaymentItemsFinished(Ljava/util/List;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 226
    .local p1, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    return-void
.end method

.method public onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 4
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 203
    .local p2, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    const-string v1, "SDKGetItemList"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "items = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 204
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 205
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;->this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    invoke-static {v1, p2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->access$000(Lcom/igg/iggsdkbusiness/ProuductGooglePay;Ljava/util/List;)Ljava/lang/String;

    move-result-object v0

    .line 207
    .local v0, "itemStr":Ljava/lang/String;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;->this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;->this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getProductCallBack:Ljava/lang/String;

    invoke-virtual {v1, v2, v0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 208
    const-string v1, "SDKGetItemList"

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 215
    .end local v0    # "itemStr":Ljava/lang/String;
    :goto_0
    return-void

    .line 212
    :cond_0
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;->this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2$2;->this$1:Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getProductCallBack:Ljava/lang/String;

    const-string v3, ""

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
