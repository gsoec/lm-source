.class public Lcom/igg/sdk/error/IGGException;
.super Ljava/lang/Exception;
.source "IGGException.java"


# static fields
.field public static final NO_EXCEPTION_CODE:Ljava/lang/String; = "0000000000"


# instance fields
.field private code:Ljava/lang/String;

.field private situation:Ljava/lang/String;

.field private suggestion:Ljava/lang/String;

.field private underlyingException:Lcom/igg/sdk/error/IGGException;


# direct methods
.method private constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "code"    # Ljava/lang/String;
    .param p2, "situation"    # Ljava/lang/String;

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Exception;-><init>()V

    .line 21
    iput-object p1, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    .line 22
    iput-object p2, p0, Lcom/igg/sdk/error/IGGException;->situation:Ljava/lang/String;

    .line 23
    return-void
.end method

.method public static exception(Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;
    .locals 2
    .param p0, "code"    # Ljava/lang/String;

    .prologue
    .line 82
    new-instance v0, Lcom/igg/sdk/error/IGGException;

    const-string v1, ""

    invoke-direct {v0, p0, v1}, Lcom/igg/sdk/error/IGGException;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 84
    .local v0, "exception":Lcom/igg/sdk/error/IGGException;
    return-object v0
.end method

.method public static exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;
    .locals 1
    .param p0, "code"    # Ljava/lang/String;
    .param p1, "situation"    # Ljava/lang/String;

    .prologue
    .line 76
    new-instance v0, Lcom/igg/sdk/error/IGGException;

    invoke-direct {v0, p0, p1}, Lcom/igg/sdk/error/IGGException;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 78
    .local v0, "exception":Lcom/igg/sdk/error/IGGException;
    return-object v0
.end method

.method public static exception(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;
    .locals 2
    .param p0, "code"    # Ljava/lang/String;
    .param p1, "suggestion"    # Ljava/lang/String;
    .param p2, "situation"    # Ljava/lang/String;
    .param p3, "underlyingException"    # Lcom/igg/sdk/error/IGGException;

    .prologue
    .line 68
    new-instance v0, Lcom/igg/sdk/error/IGGException;

    invoke-direct {v0, p0, p2}, Lcom/igg/sdk/error/IGGException;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 69
    .local v0, "exception":Lcom/igg/sdk/error/IGGException;
    invoke-virtual {v0, p1}, Lcom/igg/sdk/error/IGGException;->suggestion(Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v1

    .line 70
    invoke-virtual {v1, p3}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    .line 72
    return-object v0
.end method

.method public static noneException()Lcom/igg/sdk/error/IGGException;
    .locals 3

    .prologue
    .line 88
    new-instance v0, Lcom/igg/sdk/error/IGGException;

    const-string v1, "0000000000"

    const-string v2, ""

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/error/IGGException;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 89
    .local v0, "exception":Lcom/igg/sdk/error/IGGException;
    const-string v1, ""

    invoke-virtual {v0, v1}, Lcom/igg/sdk/error/IGGException;->suggestion(Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v1

    const/4 v2, 0x0

    .line 90
    invoke-virtual {v1, v2}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    .line 92
    return-object v0
.end method


# virtual methods
.method public getCode()Ljava/lang/String;
    .locals 1

    .prologue
    .line 34
    iget-object v0, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    return-object v0
.end method

.method public getReadableUniqueCode()Ljava/lang/String;
    .locals 4

    .prologue
    const/4 v3, 0x3

    .line 61
    iget-object v0, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    const/16 v1, 0xa

    if-ne v0, v1, :cond_0

    .line 62
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    const/4 v2, 0x0

    invoke-virtual {v1, v2, v3}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "-"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    invoke-virtual {v1, v3}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 64
    :goto_0
    return-object v0

    :cond_0
    const-string v0, ""

    goto :goto_0
.end method

.method public getSituation()Ljava/lang/String;
    .locals 1

    .prologue
    .line 38
    iget-object v0, p0, Lcom/igg/sdk/error/IGGException;->situation:Ljava/lang/String;

    return-object v0
.end method

.method public getSuggestion()Ljava/lang/String;
    .locals 1

    .prologue
    .line 42
    iget-object v0, p0, Lcom/igg/sdk/error/IGGException;->suggestion:Ljava/lang/String;

    return-object v0
.end method

.method public getUnderlyingException()Lcom/igg/sdk/error/IGGException;
    .locals 1

    .prologue
    .line 51
    iget-object v0, p0, Lcom/igg/sdk/error/IGGException;->underlyingException:Lcom/igg/sdk/error/IGGException;

    return-object v0
.end method

.method public isNone()Z
    .locals 2

    .prologue
    .line 26
    const-string v0, "0000000000"

    iget-object v1, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    return v0
.end method

.method public isOccurred()Z
    .locals 2

    .prologue
    .line 30
    const-string v0, "0000000000"

    iget-object v1, p0, Lcom/igg/sdk/error/IGGException;->code:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public suggestion(Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;
    .locals 0
    .param p1, "suggestion"    # Ljava/lang/String;

    .prologue
    .line 46
    iput-object p1, p0, Lcom/igg/sdk/error/IGGException;->suggestion:Ljava/lang/String;

    .line 47
    return-object p0
.end method

.method public underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;
    .locals 0
    .param p1, "underlyingException"    # Lcom/igg/sdk/error/IGGException;

    .prologue
    .line 55
    iput-object p1, p0, Lcom/igg/sdk/error/IGGException;->underlyingException:Lcom/igg/sdk/error/IGGException;

    .line 57
    return-object p0
.end method
