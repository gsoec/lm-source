.class public final enum Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "IGGIDC"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$IGGIDC;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field public static final enum EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field public static final enum SG:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field public static final enum SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field public static final enum TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .prologue
    const/4 v5, 0x3

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 134
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    const-string v1, "SND"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 139
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    const-string v1, "TW"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 144
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    const-string v1, "SG"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SG:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 149
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    const-string v1, "EU"

    invoke-direct {v0, v1, v5}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 130
    const/4 v0, 0x4

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SG:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    aput-object v1, v0, v5

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

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
    .line 130
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 130
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1

    .prologue
    .line 130
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method
