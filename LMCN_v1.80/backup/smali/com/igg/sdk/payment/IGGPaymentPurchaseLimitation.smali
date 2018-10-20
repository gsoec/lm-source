.class public final enum Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;
.super Ljava/lang/Enum;
.source "IGGPaymentPurchaseLimitation.java"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

.field public static final enum IGGPaymentPurchaseLimitationBoth:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

.field public static final enum IGGPaymentPurchaseLimitationDevice:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

.field public static final enum IGGPaymentPurchaseLimitationNone:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

.field public static final enum IGGPaymentPurchaseLimitationRunOutOfQuota:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

.field public static final enum IGGPaymentPurchaseLimitationUser:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;


# instance fields
.field value:I


# direct methods
.method static constructor <clinit>()V
    .locals 7

    .prologue
    const/4 v6, 0x4

    const/4 v5, 0x3

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 10
    new-instance v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    const-string v1, "IGGPaymentPurchaseLimitationNone"

    invoke-direct {v0, v1, v2, v2}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationNone:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 11
    new-instance v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    const-string v1, "IGGPaymentPurchaseLimitationUser"

    invoke-direct {v0, v1, v3, v3}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationUser:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 12
    new-instance v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    const-string v1, "IGGPaymentPurchaseLimitationDevice"

    invoke-direct {v0, v1, v4, v4}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationDevice:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 13
    new-instance v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    const-string v1, "IGGPaymentPurchaseLimitationBoth"

    invoke-direct {v0, v1, v5, v5}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationBoth:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 14
    new-instance v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    const-string v1, "IGGPaymentPurchaseLimitationRunOutOfQuota"

    invoke-direct {v0, v1, v6, v6}, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationRunOutOfQuota:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 9
    const/4 v0, 0x5

    new-array v0, v0, [Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationNone:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationUser:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationDevice:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationBoth:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    aput-object v1, v0, v5

    sget-object v1, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationRunOutOfQuota:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    aput-object v1, v0, v6

    sput-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->$VALUES:[Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0
    .param p3, "value"    # I
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)V"
        }
    .end annotation

    .prologue
    .line 18
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 19
    iput p3, p0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->value:I

    .line 20
    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 9
    const-class v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;
    .locals 1

    .prologue
    .line 9
    sget-object v0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->$VALUES:[Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    invoke-virtual {v0}, [Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    return-object v0
.end method


# virtual methods
.method public getValue()I
    .locals 1

    .prologue
    .line 23
    iget v0, p0, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->value:I

    return v0
.end method
