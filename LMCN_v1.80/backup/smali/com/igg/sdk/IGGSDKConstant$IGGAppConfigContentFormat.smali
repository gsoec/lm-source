.class public final enum Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGAppConfigContentFormat"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

.field public static final enum DEFAULT:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

.field public static final enum JSON:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

.field public static final enum XML:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 19
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    const-string v1, "DEFAULT"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->DEFAULT:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    .line 24
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    const-string v1, "JSON"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->JSON:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    .line 29
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    const-string v1, "XML"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->XML:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    .line 15
    const/4 v0, 0x3

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->DEFAULT:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->JSON:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->XML:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    aput-object v1, v0, v4

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

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
    .line 15
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 15
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .locals 1

    .prologue
    .line 15
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    return-object v0
.end method
