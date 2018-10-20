.class public final enum Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGTranslationType"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

.field public static final enum NAME:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

.field public static final enum NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .prologue
    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 199
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    const-string v1, "NORMAL"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    .line 203
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    const-string v1, "NAME"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NAME:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    .line 195
    const/4 v0, 0x2

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NAME:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    aput-object v1, v0, v3

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

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
    .line 195
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 195
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;
    .locals 1

    .prologue
    .line 195
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    return-object v0
.end method
