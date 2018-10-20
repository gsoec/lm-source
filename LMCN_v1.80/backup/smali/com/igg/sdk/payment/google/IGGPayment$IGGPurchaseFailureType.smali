.class public final enum Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;
.super Ljava/lang/Enum;
.source "IGGPayment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/google/IGGPayment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGPurchaseFailureType"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

.field public static final enum IAB_CANCELED:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

.field public static final enum IAB_PURCHASE:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

.field public static final enum IAB_SETUP:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

.field public static final enum IGG_GATEWAY:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .prologue
    const/4 v5, 0x3

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 103
    new-instance v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    const-string v1, "IAB_SETUP"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_SETUP:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    .line 108
    new-instance v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    const-string v1, "IAB_PURCHASE"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_PURCHASE:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    .line 115
    new-instance v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    const-string v1, "IGG_GATEWAY"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IGG_GATEWAY:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    .line 120
    new-instance v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    const-string v1, "IAB_CANCELED"

    invoke-direct {v0, v1, v5}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_CANCELED:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    .line 99
    const/4 v0, 0x4

    new-array v0, v0, [Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_SETUP:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_PURCHASE:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IGG_GATEWAY:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_CANCELED:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    aput-object v1, v0, v5

    sput-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->$VALUES:[Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .prologue
    .line 99
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 99
    const-class v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;
    .locals 1

    .prologue
    .line 99
    sget-object v0, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->$VALUES:[Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    invoke-virtual {v0}, [Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    return-object v0
.end method
