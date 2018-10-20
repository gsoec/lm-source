.class final Lcom/appsflyer/h$1;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/appsflyer/h;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private synthetic ˋ:Lcom/appsflyer/h;

.field private synthetic ˏ:Ljava/util/Map;


# direct methods
.method constructor <init>(Lcom/appsflyer/h;Ljava/util/Map;)V
    .locals 0

    .prologue
    .line 81
    iput-object p1, p0, Lcom/appsflyer/h$1;->ˋ:Lcom/appsflyer/h;

    iput-object p2, p0, Lcom/appsflyer/h$1;->ˏ:Ljava/util/Map;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 4

    .prologue
    .line 84
    iget-object v0, p0, Lcom/appsflyer/h$1;->ˋ:Lcom/appsflyer/h;

    iget-object v1, p0, Lcom/appsflyer/h$1;->ˏ:Ljava/util/Map;

    iget-object v2, p0, Lcom/appsflyer/h$1;->ˋ:Lcom/appsflyer/h;

    invoke-static {v2}, Lcom/appsflyer/h;->ˊ(Lcom/appsflyer/h;)Ljava/util/Map;

    move-result-object v2

    iget-object v3, p0, Lcom/appsflyer/h$1;->ˋ:Lcom/appsflyer/h;

    invoke-static {v3}, Lcom/appsflyer/h;->ˎ(Lcom/appsflyer/h;)Ljava/lang/ref/WeakReference;

    move-result-object v3

    invoke-static {v0, v1, v2, v3}, Lcom/appsflyer/h;->ॱ(Lcom/appsflyer/h;Ljava/util/Map;Ljava/util/Map;Ljava/lang/ref/WeakReference;)V

    .line 85
    return-void
.end method
