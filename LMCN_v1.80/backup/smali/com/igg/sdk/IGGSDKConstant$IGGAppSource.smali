.class public final enum Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGAppSource"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

.field public static final enum LOCAL:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

.field public static final enum REMOTE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

.field public static final enum RESCUE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 163
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    const-string v1, "REMOTE"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->REMOTE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    .line 170
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    const-string v1, "LOCAL"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->LOCAL:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    .line 175
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    const-string v1, "RESCUE"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->RESCUE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    .line 157
    const/4 v0, 0x3

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->REMOTE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->LOCAL:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->RESCUE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    aput-object v1, v0, v4

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

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
    .line 157
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 157
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;
    .locals 1

    .prologue
    .line 157
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    return-object v0
.end method
