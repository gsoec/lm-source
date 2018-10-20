.class public Lcom/igg/sdk/error/IGGError;
.super Ljava/lang/Object;
.source "IGGError.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/error/IGGError$Type;
    }
.end annotation


# instance fields
.field public addtionalDescription:Ljava/lang/String;

.field protected errorCode:I

.field protected original:Ljava/lang/Exception;

.field protected type:Lcom/igg/sdk/error/IGGError$Type;

.field public userData:Ljava/lang/Object;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V
    .locals 0
    .param p1, "type"    # Lcom/igg/sdk/error/IGGError$Type;
    .param p2, "originalException"    # Ljava/lang/Exception;

    .prologue
    .line 119
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 120
    iput-object p1, p0, Lcom/igg/sdk/error/IGGError;->type:Lcom/igg/sdk/error/IGGError$Type;

    .line 121
    iput-object p2, p0, Lcom/igg/sdk/error/IGGError;->original:Ljava/lang/Exception;

    .line 122
    return-void
.end method

.method public constructor <init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;I)V
    .locals 0
    .param p1, "type"    # Lcom/igg/sdk/error/IGGError$Type;
    .param p2, "originalException"    # Ljava/lang/Exception;
    .param p3, "errorCode"    # I

    .prologue
    .line 124
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 125
    iput-object p1, p0, Lcom/igg/sdk/error/IGGError;->type:Lcom/igg/sdk/error/IGGError$Type;

    .line 126
    iput-object p2, p0, Lcom/igg/sdk/error/IGGError;->original:Ljava/lang/Exception;

    .line 127
    iput p3, p0, Lcom/igg/sdk/error/IGGError;->errorCode:I

    .line 128
    return-void
.end method

.method public static NoneError()Lcom/igg/sdk/error/IGGError;
    .locals 3

    .prologue
    .line 67
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->NONE:Lcom/igg/sdk/error/IGGError$Type;

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    return-object v0
.end method

.method public static businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;

    .prologue
    .line 104
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v0, v1, p0}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    return-object v0
.end method

.method public static businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I

    .prologue
    .line 108
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v0, v1, p0, p1}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;I)V

    return-object v0
.end method

.method public static businessError(Ljava/lang/Exception;ILjava/lang/String;)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I
    .param p2, "description"    # Ljava/lang/String;

    .prologue
    .line 112
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    const/4 v1, 0x0

    invoke-static {v0, p0, p1, p2, v1}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method

.method public static businessError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;
    .locals 1
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I
    .param p2, "description"    # Ljava/lang/String;
    .param p3, "userData"    # Ljava/lang/Object;

    .prologue
    .line 116
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    invoke-static {v0, p0, p1, p2, p3}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method

.method public static errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;
    .locals 1
    .param p0, "type"    # Lcom/igg/sdk/error/IGGError$Type;
    .param p1, "originalException"    # Ljava/lang/Exception;
    .param p2, "errorCode"    # I
    .param p3, "description"    # Ljava/lang/String;
    .param p4, "userData"    # Ljava/lang/Object;

    .prologue
    .line 59
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    invoke-direct {v0, p0, p1, p2}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;I)V

    .line 60
    .local v0, "error":Lcom/igg/sdk/error/IGGError;
    iput-object p3, v0, Lcom/igg/sdk/error/IGGError;->addtionalDescription:Ljava/lang/String;

    .line 61
    iput-object p4, v0, Lcom/igg/sdk/error/IGGError;->userData:Ljava/lang/Object;

    .line 63
    return-object v0
.end method

.method public static errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/String;I)Lcom/igg/sdk/error/IGGError;
    .locals 1
    .param p0, "type"    # Lcom/igg/sdk/error/IGGError$Type;
    .param p1, "description"    # Ljava/lang/String;
    .param p2, "errorCode"    # I

    .prologue
    .line 53
    invoke-static {p0, p1, p2}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/String;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method

.method public static remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;

    .prologue
    .line 88
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->REMOTE:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v0, v1, p0}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    return-object v0
.end method

.method public static remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I

    .prologue
    .line 92
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v0, v1, p0, p1}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;I)V

    return-object v0
.end method

.method public static remoteError(Ljava/lang/Exception;ILjava/lang/String;)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I
    .param p2, "description"    # Ljava/lang/String;

    .prologue
    .line 96
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->REMOTE:Lcom/igg/sdk/error/IGGError$Type;

    const/4 v1, 0x0

    invoke-static {v0, p0, p1, p2, v1}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method

.method public static remoteError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;
    .locals 1
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I
    .param p2, "description"    # Ljava/lang/String;
    .param p3, "userData"    # Ljava/lang/Object;

    .prologue
    .line 100
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->REMOTE:Lcom/igg/sdk/error/IGGError$Type;

    invoke-static {v0, p0, p1, p2, p3}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method

.method public static systemError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;

    .prologue
    .line 71
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v0, v1, p0}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    return-object v0
.end method

.method public static systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I

    .prologue
    .line 75
    new-instance v0, Lcom/igg/sdk/error/IGGError;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v0, v1, p0, p1}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;I)V

    return-object v0
.end method

.method public static systemError(Ljava/lang/Exception;ILjava/lang/String;)Lcom/igg/sdk/error/IGGError;
    .locals 2
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I
    .param p2, "description"    # Ljava/lang/String;

    .prologue
    .line 79
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    const/4 v1, 0x0

    invoke-static {v0, p0, p1, p2, v1}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method

.method public static systemError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;
    .locals 1
    .param p0, "originalException"    # Ljava/lang/Exception;
    .param p1, "errorCode"    # I
    .param p2, "description"    # Ljava/lang/String;
    .param p3, "userData"    # Ljava/lang/Object;

    .prologue
    .line 83
    sget-object v0, Lcom/igg/sdk/error/IGGError$Type;->SYSTEM:Lcom/igg/sdk/error/IGGError$Type;

    invoke-static {v0, p0, p1, p2, p3}, Lcom/igg/sdk/error/IGGError;->errorWithDescription(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public getErrorCode()I
    .locals 1

    .prologue
    .line 131
    iget v0, p0, Lcom/igg/sdk/error/IGGError;->errorCode:I

    return v0
.end method

.method public getOriginal()Ljava/lang/Exception;
    .locals 1

    .prologue
    .line 157
    iget-object v0, p0, Lcom/igg/sdk/error/IGGError;->original:Ljava/lang/Exception;

    if-nez v0, :cond_0

    .line 158
    new-instance v0, Ljava/lang/Exception;

    invoke-direct {v0}, Ljava/lang/Exception;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/error/IGGError;->original:Ljava/lang/Exception;

    .line 161
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/error/IGGError;->original:Ljava/lang/Exception;

    return-object v0
.end method

.method public getType()Lcom/igg/sdk/error/IGGError$Type;
    .locals 1

    .prologue
    .line 153
    iget-object v0, p0, Lcom/igg/sdk/error/IGGError;->type:Lcom/igg/sdk/error/IGGError$Type;

    return-object v0
.end method

.method public isNone()Z
    .locals 2

    .prologue
    .line 140
    iget-object v0, p0, Lcom/igg/sdk/error/IGGError;->type:Lcom/igg/sdk/error/IGGError$Type;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->NONE:Lcom/igg/sdk/error/IGGError$Type;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public isOccurred()Z
    .locals 2

    .prologue
    .line 149
    iget-object v0, p0, Lcom/igg/sdk/error/IGGError;->type:Lcom/igg/sdk/error/IGGError$Type;

    sget-object v1, Lcom/igg/sdk/error/IGGError$Type;->NONE:Lcom/igg/sdk/error/IGGError$Type;

    if-eq v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method
