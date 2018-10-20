.class public final Lcom/ta/utdid2/device/c;
.super Ljava/lang/Object;
.source "SourceFile"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static a(Landroid/content/Context;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 18
    invoke-static {p0}, Lcom/ta/utdid2/device/b;->a(Landroid/content/Context;)Lcom/ta/utdid2/device/a;

    move-result-object v0

    .line 19
    if-eqz v0, :cond_0

    .line 1059
    iget-object v1, v0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    .line 19
    invoke-static {v1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    const-string v0, "ffffffffffffffffffffffff"

    :goto_0
    return-object v0

    .line 2059
    :cond_1
    iget-object v0, v0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    goto :goto_0
.end method
