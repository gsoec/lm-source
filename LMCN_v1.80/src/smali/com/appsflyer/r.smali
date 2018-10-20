.class final Lcom/appsflyer/r;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Lcom/appsflyer/r$a;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/r$a;,
        Lcom/appsflyer/r$c;
    }
.end annotation


# instance fields
.field private ˊ:Lcom/appsflyer/r$a;


# direct methods
.method constructor <init>()V
    .locals 0

    .prologue
    .line 55
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 56
    iput-object p0, p0, Lcom/appsflyer/r;->ˊ:Lcom/appsflyer/r$a;

    .line 62
    return-void
.end method


# virtual methods
.method final ˊ(Ljava/lang/String;)Z
    .locals 3

    .prologue
    const/4 v0, 0x0

    .line 70
    :try_start_0
    iget-object v1, p0, Lcom/appsflyer/r;->ˊ:Lcom/appsflyer/r$a;

    invoke-interface {v1, p1}, Lcom/appsflyer/r$a;->ˎ(Ljava/lang/String;)Ljava/lang/Class;

    .line 71
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "Class: "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, " is found."

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 72
    const/4 v0, 0x1

    .line 78
    :goto_0
    return v0

    .line 75
    :catch_0
    move-exception v1

    .line 76
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 74
    :catch_1
    move-exception v1

    goto :goto_0
.end method

.method final ˋ()Ljava/lang/String;
    .locals 5

    .prologue
    .line 47
    invoke-static {}, Lcom/appsflyer/r$c;->values()[Lcom/appsflyer/r$c;

    move-result-object v1

    array-length v2, v1

    const/4 v0, 0x0

    :goto_0
    if-ge v0, v2, :cond_1

    aget-object v3, v1, v0

    .line 48
    invoke-static {v3}, Lcom/appsflyer/r$c;->ˏ(Lcom/appsflyer/r$c;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {p0, v4}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 49
    invoke-static {v3}, Lcom/appsflyer/r$c;->ˎ(Lcom/appsflyer/r$c;)Ljava/lang/String;

    move-result-object v0

    .line 52
    :goto_1
    return-object v0

    .line 47
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 52
    :cond_1
    sget-object v0, Lcom/appsflyer/r$c;->ॱ:Lcom/appsflyer/r$c;

    invoke-static {v0}, Lcom/appsflyer/r$c;->ˎ(Lcom/appsflyer/r$c;)Ljava/lang/String;

    move-result-object v0

    goto :goto_1
.end method

.method public final ˎ(Ljava/lang/String;)Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Ljava/lang/Class",
            "<*>;"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/ClassNotFoundException;
        }
    .end annotation

    .prologue
    .line 3059
    invoke-static {p1}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v0

    return-object v0
.end method
