.class Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;
.super Ljava/lang/Object;
.source "IGGAliPay.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

.field final synthetic val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

.field final synthetic val$body:Ljava/lang/String;

.field final synthetic val$itemId:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

.field final synthetic val$price:Ljava/lang/String;

.field final synthetic val$quantity:Ljava/lang/String;

.field final synthetic val$subject:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    .prologue
    .line 89
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$itemId:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$subject:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$body:Ljava/lang/String;

    iput-object p6, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$price:Ljava/lang/String;

    iput-object p7, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$quantity:Ljava/lang/String;

    iput-object p8, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFinished(ILcom/igg/sdk/error/IGGError;)V
    .locals 7
    .param p1, "purchaseLimitation"    # I
    .param p2, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 92
    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 93
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;->onRequestError()V

    .line 102
    :goto_0
    return-void

    .line 97
    :cond_0
    if-lez p1, :cond_1

    .line 98
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;->onLimint()V

    goto :goto_0

    .line 101
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$itemId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$subject:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$body:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$price:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$quantity:Ljava/lang/String;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-virtual/range {v0 .. v6}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    goto :goto_0
.end method
