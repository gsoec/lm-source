.class public final enum Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGMobileDeviceMessageState"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

.field public static final enum OFFLINE_ARRIVAL:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

.field public static final enum OFFLINE_READ:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

.field public static final enum ONLINE_ARRIVAL:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 41
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    const-string v1, "OFFLINE_ARRIVAL"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->OFFLINE_ARRIVAL:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    .line 46
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    const-string v1, "OFFLINE_READ"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->OFFLINE_READ:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    .line 51
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    const-string v1, "ONLINE_ARRIVAL"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->ONLINE_ARRIVAL:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    .line 37
    const/4 v0, 0x3

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->OFFLINE_ARRIVAL:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->OFFLINE_READ:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->ONLINE_ARRIVAL:Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    aput-object v1, v0, v4

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

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
    .line 37
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 37
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;
    .locals 1

    .prologue
    .line 37
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;

    return-object v0
.end method
