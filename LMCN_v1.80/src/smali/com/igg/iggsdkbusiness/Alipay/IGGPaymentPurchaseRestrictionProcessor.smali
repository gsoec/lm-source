.class public Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;
.super Ljava/lang/Object;
.source "IGGPaymentPurchaseRestrictionProcessor.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;
    }
.end annotation


# instance fields
.field private gameId:Ljava/lang/String;

.field private iggId:Ljava/lang/String;

.field private pcId:I

.field private restriction:Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;ILcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "iggId"    # Ljava/lang/String;
    .param p3, "pcId"    # I
    .param p4, "restriction"    # Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    .prologue
    .line 31
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 32
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->gameId:Ljava/lang/String;

    .line 33
    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->iggId:Ljava/lang/String;

    .line 34
    iput p3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->pcId:I

    .line 35
    iput-object p4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->restriction:Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    .line 36
    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;
    .param p1, "x1"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    .prologue
    .line 21
    invoke-direct {p0, p1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->queryUserLimitationWithAcceleratedRoute(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    return-void
.end method

.method static synthetic access$100(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Ljava/util/List;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;
    .param p1, "x1"    # Ljava/util/List;
    .param p2, "x2"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    .prologue
    .line 21
    invoke-direct {p0, p1, p2}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->processorUserLimitationResponse(Ljava/util/List;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    return-void
.end method

.method private processorUserLimitationResponse(Ljava/util/List;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
    .locals 6
    .param p2, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;",
            ">;",
            "Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 71
    .local p1, "results":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;>;"
    sget-object v3, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationNone:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v3}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->getValue()I

    move-result v1

    .line 72
    .local v1, "purchaseLimitation":I
    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;

    .line 73
    .local v2, "result":Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;
    invoke-virtual {v2}, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->isLimit()Z

    move-result v0

    .line 74
    .local v0, "isLimit":Z
    if-eqz v0, :cond_0

    .line 75
    sget-object v4, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$3;->$SwitchMap$com$igg$sdk$payment$IGGPaymentPurchaseLimitation:[I

    invoke-virtual {v2}, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->getLimitation()Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->ordinal()I

    move-result v5

    aget v4, v4, v5

    packed-switch v4, :pswitch_data_0

    goto :goto_0

    .line 77
    :pswitch_0
    sget-object v4, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationUser:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->getValue()I

    move-result v4

    or-int/2addr v1, v4

    .line 78
    goto :goto_0

    .line 81
    :pswitch_1
    sget-object v4, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationDevice:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->getValue()I

    move-result v4

    or-int/2addr v1, v4

    .line 82
    goto :goto_0

    .line 85
    :pswitch_2
    sget-object v4, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationRunOutOfQuota:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->getValue()I

    move-result v4

    or-int/2addr v1, v4

    .line 86
    goto :goto_0

    .line 95
    .end local v0    # "isLimit":Z
    .end local v2    # "result":Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;
    :cond_1
    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    invoke-interface {p2, v1, v3}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;->onFinished(ILcom/igg/sdk/error/IGGError;)V

    .line 96
    return-void

    .line 75
    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method

.method private queryUserLimitationWithAcceleratedRoute(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
    .locals 8
    .param p1, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    .prologue
    const/4 v6, 0x0

    .line 55
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    .line 56
    .local v0, "service":Lcom/igg/sdk/service/IGGPaymentService;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->iggId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->gameId:Ljava/lang/String;

    iget v3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->pcId:I

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->restriction:Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->isAntiAddictionEnable()Z

    move-result v4

    if-eqz v4, :cond_0

    const/4 v4, 0x1

    :goto_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->restriction:Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    invoke-virtual {v5}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->getAntiAddictionPeriodCostQuota()F

    move-result v5

    new-instance v7, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$2;

    invoke-direct {v7, p0, p1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$2;-><init>(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    invoke-virtual/range {v0 .. v7}, Lcom/igg/sdk/service/IGGPaymentService;->requestLimitState(Ljava/lang/String;Ljava/lang/String;IIFZLcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;)V

    .line 68
    return-void

    :cond_0
    move v4, v6

    .line 56
    goto :goto_0
.end method


# virtual methods
.method public process(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V
    .locals 8
    .param p1, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;

    .prologue
    const/4 v6, 0x0

    .line 39
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    .line 40
    .local v0, "service":Lcom/igg/sdk/service/IGGPaymentService;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->iggId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->gameId:Ljava/lang/String;

    iget v3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->pcId:I

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->restriction:Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->isAntiAddictionEnable()Z

    move-result v4

    if-eqz v4, :cond_0

    const/4 v4, 0x1

    :goto_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->restriction:Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    invoke-virtual {v5}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->getAntiAddictionPeriodCostQuota()F

    move-result v5

    new-instance v7, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;

    invoke-direct {v7, p0, p1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$1;-><init>(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    invoke-virtual/range {v0 .. v7}, Lcom/igg/sdk/service/IGGPaymentService;->requestLimitState(Ljava/lang/String;Ljava/lang/String;IIFZLcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;)V

    .line 51
    return-void

    :cond_0
    move v4, v6

    .line 40
    goto :goto_0
.end method
