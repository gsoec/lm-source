.class final Lcom/appsflyer/AppsFlyerLib$a;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/AppsFlyerLib;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "a"
.end annotation


# instance fields
.field private ʻ:Ljava/util/concurrent/ExecutorService;

.field private ʼ:Z

.field private ʽ:Z

.field private ˊ:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;"
        }
    .end annotation
.end field

.field private ˋ:Ljava/lang/String;

.field private final ˎ:Landroid/content/Intent;

.field private ˏ:Ljava/lang/String;

.field private ॱ:Ljava/lang/String;

.field private synthetic ॱॱ:Lcom/appsflyer/AppsFlyerLib;

.field private ᐝ:Ljava/lang/String;


# direct methods
.method private constructor <init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/ref/WeakReference;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/concurrent/ExecutorService;ZLandroid/content/Intent;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "ZZ",
            "Landroid/content/Intent;",
            ")V"
        }
    .end annotation

    .prologue
    .line 3006
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$a;->ॱॱ:Lcom/appsflyer/AppsFlyerLib;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 3007
    iput-object p2, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˊ:Ljava/lang/ref/WeakReference;

    .line 3008
    iput-object p3, p0, Lcom/appsflyer/AppsFlyerLib$a;->ॱ:Ljava/lang/String;

    .line 3009
    iput-object p4, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˏ:Ljava/lang/String;

    .line 3010
    iput-object p5, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˋ:Ljava/lang/String;

    .line 3011
    iput-object p6, p0, Lcom/appsflyer/AppsFlyerLib$a;->ᐝ:Ljava/lang/String;

    .line 3012
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib$a;->ʼ:Z

    .line 3013
    iput-object p7, p0, Lcom/appsflyer/AppsFlyerLib$a;->ʻ:Ljava/util/concurrent/ExecutorService;

    .line 3014
    iput-boolean p8, p0, Lcom/appsflyer/AppsFlyerLib$a;->ʽ:Z

    .line 3015
    iput-object p9, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˎ:Landroid/content/Intent;

    .line 3016
    return-void
.end method

.method synthetic constructor <init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/ref/WeakReference;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/concurrent/ExecutorService;ZLandroid/content/Intent;B)V
    .locals 0

    .prologue
    .line 2987
    invoke-direct/range {p0 .. p9}, Lcom/appsflyer/AppsFlyerLib$a;-><init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/ref/WeakReference;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/concurrent/ExecutorService;ZLandroid/content/Intent;)V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 9

    .prologue
    .line 3019
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$a;->ॱॱ:Lcom/appsflyer/AppsFlyerLib;

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/content/Context;

    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib$a;->ॱ:Ljava/lang/String;

    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˏ:Ljava/lang/String;

    iget-object v4, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˋ:Ljava/lang/String;

    iget-object v5, p0, Lcom/appsflyer/AppsFlyerLib$a;->ᐝ:Ljava/lang/String;

    iget-boolean v6, p0, Lcom/appsflyer/AppsFlyerLib$a;->ʼ:Z

    iget-boolean v7, p0, Lcom/appsflyer/AppsFlyerLib$a;->ʽ:Z

    iget-object v8, p0, Lcom/appsflyer/AppsFlyerLib$a;->ˎ:Landroid/content/Intent;

    invoke-static/range {v0 .. v8}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZZLandroid/content/Intent;)V

    .line 3022
    return-void
.end method
