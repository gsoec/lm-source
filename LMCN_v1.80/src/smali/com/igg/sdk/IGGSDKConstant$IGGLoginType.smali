.class public final enum Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGLoginType"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum AMAZON:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum GUEST:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum IGG:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum NONE:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum VK:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field public static final enum WECHAT:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;


# direct methods
.method static constructor <clinit>()V
    .locals 8

    .prologue
    const/4 v7, 0x4

    const/4 v6, 0x3

    const/4 v5, 0x2

    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 63
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "NONE"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->NONE:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 68
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "GUEST"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GUEST:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 73
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "GOOGLE_PLAY"

    invoke-direct {v0, v1, v5}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 78
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "IGG"

    invoke-direct {v0, v1, v6}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 83
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "Facebook"

    invoke-direct {v0, v1, v7}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 89
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "WECHAT"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->WECHAT:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 94
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "AMAZON"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->AMAZON:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 99
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "VK"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->VK:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 59
    const/16 v0, 0x8

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->NONE:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GUEST:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v1, v0, v5

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v1, v0, v6

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v1, v0, v7

    const/4 v1, 0x5

    sget-object v2, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->WECHAT:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v2, v0, v1

    const/4 v1, 0x6

    sget-object v2, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->AMAZON:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v2, v0, v1

    const/4 v1, 0x7

    sget-object v2, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->VK:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    aput-object v2, v0, v1

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

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
    .line 59
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 59
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    .locals 1

    .prologue
    .line 59
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    return-object v0
.end method
