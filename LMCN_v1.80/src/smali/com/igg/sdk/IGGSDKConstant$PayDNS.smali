.class public final enum Lcom/igg/sdk/IGGSDKConstant$PayDNS;
.super Ljava/lang/Enum;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDKConstant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "PayDNS"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/IGGSDKConstant$PayDNS;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/IGGSDKConstant$PayDNS;

.field public static final enum PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

.field public static final enum PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .prologue
    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 221
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v1, "PAY_SKYUNION"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/IGGSDKConstant$PayDNS;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    .line 225
    new-instance v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v1, "PAY_APP_IGG"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/IGGSDKConstant$PayDNS;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    .line 217
    const/4 v0, 0x2

    new-array v0, v0, [Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    aput-object v1, v0, v3

    sput-object v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$PayDNS;

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
    .line 217
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$PayDNS;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 217
    const-class v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/IGGSDKConstant$PayDNS;
    .locals 1

    .prologue
    .line 217
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->$VALUES:[Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    invoke-virtual {v0}, [Lcom/igg/sdk/IGGSDKConstant$PayDNS;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    return-object v0
.end method
