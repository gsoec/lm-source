.class public final enum Lcom/igg/sdk/IGGSDKConstant$PaymentType;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "PaymentType"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$PaymentType;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$PaymentType;

.field public static final enum BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

.field public static final enum GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$PaymentType;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .prologue
    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 210
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    const-string v1, "GOOGLE_PLAY"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$PaymentType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    .line 214
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    const-string v1, "BAZAAR"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$PaymentType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    .line 206
    const/4 v0, 0x2

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    aput-object v1, v0, v3

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$PaymentType;

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
    .line 206
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$PaymentType;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 206
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$PaymentType;
    .locals 1

    .prologue
    .line 206
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$PaymentType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    return-object v0
.end method
