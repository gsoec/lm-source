.class Lcom/igg/iggsdkbusiness/WeChatHelper$3;
.super Ljava/lang/Object;
.source "WeChatHelper.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

.field final synthetic val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

.field final synthetic val$itemId:Ljava/lang/String;

.field final synthetic val$itemName:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

.field final synthetic val$payInfo:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$price:Ljava/lang/String;

.field final synthetic val$quantity:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/WeChatHelper;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/WeChatHelper;

    .prologue
    .line 312
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$payInfo:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$itemId:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$itemName:Ljava/lang/String;

    iput-object p6, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$price:Ljava/lang/String;

    iput-object p7, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$quantity:Ljava/lang/String;

    iput-object p8, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFinished(ILcom/igg/sdk/error/IGGError;)V
    .locals 7
    .param p1, "purchaseLimitation"    # I
    .param p2, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 315
    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 316
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;->onRequestError()V

    .line 325
    :goto_0
    return-void

    .line 320
    :cond_0
    if-lez p1, :cond_1

    .line 321
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$amoutOfLimitListener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;->onLimint()V

    goto :goto_0

    .line 324
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$payInfo:Lcom/igg/sdk/service/IGGPaymentService;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$itemId:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$itemName:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$price:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$quantity:Ljava/lang/String;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$3;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    invoke-virtual/range {v0 .. v6}, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V

    goto :goto_0
.end method
