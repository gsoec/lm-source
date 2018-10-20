.class public final enum Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "ThirdAccountType"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

.field public static final enum ALL_TYPE:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

.field public static final enum AMAZON:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

.field public static final enum FACEBOOK:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

.field public static final enum GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

.field public static final enum WECHAT:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;


# direct methods
.method static constructor <clinit>()V
    .locals 7

    .prologue
    const/4 v6, 0x4

    const/4 v5, 0x3

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 237
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    const-string v1, "GOOGLE_PLAY"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    .line 242
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    const-string v1, "FACEBOOK"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->FACEBOOK:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    .line 247
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    const-string v1, "WECHAT"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->WECHAT:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    .line 252
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    const-string v1, "AMAZON"

    invoke-direct {v0, v1, v5}, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->AMAZON:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    .line 257
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    const-string v1, "ALL_TYPE"

    invoke-direct {v0, v1, v6}, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->ALL_TYPE:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    .line 233
    const/4 v0, 0x5

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->FACEBOOK:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->WECHAT:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->AMAZON:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    aput-object v1, v0, v5

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->ALL_TYPE:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    aput-object v1, v0, v6

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

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
    .line 233
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 233
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;
    .locals 1

    .prologue
    .line 233
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    return-object v0
.end method
