.class public final enum Lcom/igg/sdk/IGGSDKConstant$CDNType;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "CDNType"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$CDNType;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$CDNType;

.field public static final enum DYNAMIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

.field public static final enum STATIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .prologue
    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 111
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;

    const-string v1, "STATIC_ADDRESS"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$CDNType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;->STATIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    .line 116
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;

    const-string v1, "DYNAMIC_ADDRESS"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$CDNType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;->DYNAMIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    .line 107
    const/4 v0, 0x2

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$CDNType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$CDNType;->STATIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$CDNType;->DYNAMIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    aput-object v1, v0, v3

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$CDNType;

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
    .line 107
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$CDNType;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 107
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$CDNType;
    .locals 1

    .prologue
    .line 107
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$CDNType;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$CDNType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$CDNType;

    return-object v0
.end method
