.class public final enum Lcom/igg/sdk/error/IGGError$Type;
.super Ljava/lang/Enum;
.source "IGGError.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/error/IGGError;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Type"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/error/IGGError$Type;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/error/IGGError$Type;

.field public static final enum BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

.field public static final enum NONE:Lcom/igg/sdk/error/IGGError$Type;

.field public static final enum REMOTE:Lcom/igg/sdk/error/IGGError$Type;

.field public static final enum SYSTEM:Lcom/igg/sdk/error/IGGError$Type;


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .prologue
    const/4 v5, 0x3

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 28
    new-instance v0, Lcom/igg/sdk/error/IGGError$Type;

    const-string v1, "NONE"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/error/IGGError$Type;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/error/IGGError$Type;->NONE:Lcom/igg/sdk/error/IGGError$Type;

    .line 35
    new-instance v0, Lcom/igg/sdk/error/IGGError$Type;

    const-string v1, "SYSTEM"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/error/IGGError$Type;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    .line 42
    new-instance v0, Lcom/igg/sdk/error/IGGError$Type;

    const-string v1, "REMOTE"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/error/IGGError$Type;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/error/IGGError$Type;->REMOTE:Lcom/igg/sdk/error/IGGError$Type;

    .line 49
    new-instance v0, Lcom/igg/sdk/error/IGGError$Type;

    const-string v1, "BUSINESS"

    invoke-direct {v0, v1, v5}, Lcom/igg/sdk/error/IGGError$Type;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    .line 24
    const/4 v0, 0x4

    new-array v0, v0, [Lcom/igg/sdk/error/IGGError$Type;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->NONE:Lcom/igg/sdk/error/IGGError$Type;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->REMOTE:Lcom/igg/sdk/error/IGGError$Type;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    aput-object v1, v0, v5

    sput-object v0, Lcom/igg/sdk/error/IGGError$Type;->$VALUES:[Lcom/igg/sdk/error/IGGError$Type;

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
    .line 24
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/error/IGGError$Type;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 24
    const-class v0, Lcom/igg/sdk/error/IGGError$Type;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/error/IGGError$Type;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/error/IGGError$Type;
    .locals 1

    .prologue
    .line 24
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->$VALUES:[Lcom/igg/sdk/error/IGGError$Type;

    invoke-virtual {v0}, [Lcom/igg/sdk/error/IGGError$Type;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/error/IGGError$Type;

    return-object v0
.end method
