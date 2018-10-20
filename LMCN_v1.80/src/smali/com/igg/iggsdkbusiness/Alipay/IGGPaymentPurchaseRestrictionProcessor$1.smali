.class Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;
.super Ljava/lang/Object;
.source "IGGPaymentPurchaseRestrictionProcessor.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->process(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

    .prologue
    .line 40
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentLimitStateFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 2
    .param p1, "iggError"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 43
    .local p2, "results":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 44
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    invoke-static {v0, v1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->access$000(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    .line 49
    :goto_0
    return-void

    .line 48
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    invoke-static {v0, p2, v1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->access$100(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Ljava/util/List;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    goto :goto_0
.end method
