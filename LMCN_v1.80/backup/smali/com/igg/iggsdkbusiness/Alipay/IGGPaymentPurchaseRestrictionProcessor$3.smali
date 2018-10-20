.class synthetic Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$3;
.super Ljava/lang/Object;
.source "IGGPaymentPurchaseRestrictionProcessor.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1008
    name = null
.end annotation


# static fields
.field static final synthetic $SwitchMap$com$igg$sdk$payment$IGGPaymentPurchaseLimitation:[I


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .prologue
    .line 75
    invoke-static {}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->values()[Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    move-result-object v0

    array-length v0, v0

    new-array v0, v0, [I

    sput-object v0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$3;->$SwitchMap$com$igg$sdk$payment$IGGPaymentPurchaseLimitation:[I

    :try_start_0
    sget-object v0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$3;->$SwitchMap$com$igg$sdk$payment$IGGPaymentPurchaseLimitation:[I

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationUser:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->ordinal()I

    move-result v1

    const/4 v2, 0x1

    aput v2, v0, v1
    :try_end_0
    .catch Ljava/lang/NoSuchFieldError; {:try_start_0 .. :try_end_0} :catch_2

    :goto_0
    :try_start_1
    sget-object v0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$3;->$SwitchMap$com$igg$sdk$payment$IGGPaymentPurchaseLimitation:[I

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationDevice:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->ordinal()I

    move-result v1

    const/4 v2, 0x2

    aput v2, v0, v1
    :try_end_1
    .catch Ljava/lang/NoSuchFieldError; {:try_start_1 .. :try_end_1} :catch_1

    :goto_1
    :try_start_2
    sget-object v0, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$3;->$SwitchMap$com$igg$sdk$payment$IGGPaymentPurchaseLimitation:[I

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationRunOutOfQuota:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->ordinal()I

    move-result v1

    const/4 v2, 0x3

    aput v2, v0, v1
    :try_end_2
    .catch Ljava/lang/NoSuchFieldError; {:try_start_2 .. :try_end_2} :catch_0

    :goto_2
    return-void

    :catch_0
    move-exception v0

    goto :goto_2

    :catch_1
    move-exception v0

    goto :goto_1

    :catch_2
    move-exception v0

    goto :goto_0
.end method
