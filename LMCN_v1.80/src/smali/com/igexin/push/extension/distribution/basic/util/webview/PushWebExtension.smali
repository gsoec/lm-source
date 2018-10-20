.class public Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;
.super Ljava/lang/Object;


# instance fields
.field a:Landroid/app/Activity;

.field private b:Lcom/igexin/push/core/bean/PushTaskBean;

.field private c:Ljava/lang/String;

.field private d:Ljava/lang/String;


# direct methods
.method public constructor <init>(Landroid/app/Activity;Lcom/igexin/push/core/bean/PushTaskBean;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->b:Lcom/igexin/push/core/bean/PushTaskBean;

    invoke-virtual {p2}, Lcom/igexin/push/core/bean/PushTaskBean;->getTaskId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->c:Ljava/lang/String;

    invoke-virtual {p2}, Lcom/igexin/push/core/bean/PushTaskBean;->getMessageId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->d:Ljava/lang/String;

    return-void
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/b/b;)V
    .locals 3

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/b/b;->a()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_0

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/c/j;->a:Landroid/content/Context;

    const-string v1, "ext_download.db"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/g/a;->a(Landroid/content/Context;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/g/a;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/g/a/a;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/g/c/a;

    invoke-direct {v2}, Lcom/igexin/push/extension/distribution/basic/g/c/a;-><init>()V

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/g/a/a;-><init>(Lcom/igexin/push/extension/distribution/basic/g/d/a;)V

    invoke-virtual {v1, p1}, Lcom/igexin/push/extension/distribution/basic/g/a/a;->a(Lcom/igexin/push/extension/distribution/basic/b/b;)V

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/g/a;->a(Lcom/igexin/push/extension/distribution/basic/g/a/a;)J

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->b:Lcom/igexin/push/core/bean/PushTaskBean;

    const-string v2, "10050"

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;)V

    :cond_0
    return-void
.end method

.method static synthetic a(Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;Lcom/igexin/push/extension/distribution/basic/b/b;)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a(Lcom/igexin/push/extension/distribution/basic/b/b;)V

    return-void
.end method


# virtual methods
.method public appdownload(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZZ)V
    .locals 6
    .annotation runtime Landroid/webkit/JavascriptInterface;
    .end annotation

    :try_start_0
    new-instance v4, Lcom/igexin/push/extension/distribution/basic/b/b;

    invoke-direct {v4}, Lcom/igexin/push/extension/distribution/basic/b/b;-><init>()V

    invoke-virtual {v4, p3}, Lcom/igexin/push/extension/distribution/basic/b/b;->d(Ljava/lang/String;)V

    invoke-virtual {v4, p1}, Lcom/igexin/push/extension/distribution/basic/b/b;->a(Ljava/lang/String;)V

    invoke-virtual {v4, p2}, Lcom/igexin/push/extension/distribution/basic/b/b;->b(Ljava/lang/String;)V

    const-string v0, "10050"

    invoke-virtual {v4, v0}, Lcom/igexin/push/extension/distribution/basic/b/b;->setActionId(Ljava/lang/String;)V

    invoke-virtual {v4, p4}, Lcom/igexin/push/extension/distribution/basic/b/b;->e(Ljava/lang/String;)V

    const-string v0, "100"

    invoke-virtual {v4, v0}, Lcom/igexin/push/extension/distribution/basic/b/b;->setDoActionId(Ljava/lang/String;)V

    invoke-virtual {v4, p5}, Lcom/igexin/push/extension/distribution/basic/b/b;->b(Z)V

    invoke-virtual {v4, p6}, Lcom/igexin/push/extension/distribution/basic/b/b;->a(Z)V

    const/4 v0, 0x1

    invoke-virtual {v4, v0}, Lcom/igexin/push/extension/distribution/basic/b/b;->e(Z)V

    invoke-virtual {v4, p4}, Lcom/igexin/push/extension/distribution/basic/b/b;->f(Ljava/lang/String;)V

    const-string v0, "appdownload"

    invoke-virtual {v4, v0}, Lcom/igexin/push/extension/distribution/basic/b/b;->setType(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->b:Lcom/igexin/push/core/bean/PushTaskBean;

    invoke-virtual {v4, v0}, Lcom/igexin/push/extension/distribution/basic/b/b;->a(Lcom/igexin/push/core/bean/PushTaskBean;)V

    if-eqz p2, :cond_0

    const-string v0, "http"

    invoke-virtual {p2, v0}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/c/g;->a()Lcom/igexin/push/extension/distribution/basic/c/g;

    move-result-object v0

    invoke-virtual {v0, p2}, Lcom/igexin/push/extension/distribution/basic/c/g;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->c:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->d:Ljava/lang/String;

    const/4 v5, 0x1

    move-object v0, p0

    move-object v1, p2

    invoke-virtual/range {v0 .. v5}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->prepareExecuteAction(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V

    :goto_0
    return-void

    :cond_0
    invoke-direct {p0, v4}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a(Lcom/igexin/push/extension/distribution/basic/b/b;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method public close()V
    .locals 1
    .annotation runtime Landroid/webkit/JavascriptInterface;
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->finish()V

    return-void
.end method

.method public dial(Ljava/lang/String;)V
    .locals 4
    .annotation runtime Landroid/webkit/JavascriptInterface;
    .end annotation

    :try_start_0
    new-instance v0, Landroid/content/Intent;

    const-string v1, "android.intent.action.CALL"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "tel:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    invoke-direct {v0, v1, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    const/high16 v1, 0x10000000

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setFlags(I)Landroid/content/Intent;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    invoke-virtual {v1, v0}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->b:Lcom/igexin/push/core/bean/PushTaskBean;

    const-string v2, "10140"

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/SecurityException; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method public prepareExecuteAction(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V
    .locals 9

    new-instance v8, Lcom/igexin/push/extension/distribution/basic/h/d;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;

    move-object v1, p0

    move-object v2, p4

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    move v6, p5

    invoke-direct/range {v0 .. v6}, Lcom/igexin/push/extension/distribution/basic/util/webview/d;-><init>(Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;Lcom/igexin/push/core/bean/BaseAction;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V

    move-object v1, v8

    move-object v2, p1

    move-object v3, p1

    move-object v4, p2

    move-object v5, p4

    move v6, p5

    move-object v7, v0

    invoke-direct/range {v1 .. v7}, Lcom/igexin/push/extension/distribution/basic/h/d;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;ILcom/igexin/push/extension/distribution/basic/h/g;)V

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/h/a;

    invoke-direct {v1, v8}, Lcom/igexin/push/extension/distribution/basic/h/a;-><init>(Lcom/igexin/push/extension/distribution/basic/h/f;)V

    move-object v0, p4

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/b;

    check-cast p4, Lcom/igexin/push/extension/distribution/basic/b/b;

    invoke-virtual {p4}, Lcom/igexin/push/extension/distribution/basic/b/b;->l()I

    move-result v2

    add-int/lit8 v2, v2, 0x1

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/b/b;->a(I)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    return-void
.end method

.method public startapp(Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;)V
    .locals 4
    .annotation runtime Landroid/webkit/JavascriptInterface;
    .end annotation

    const/4 v0, 0x1

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    invoke-virtual {v2}, Landroid/app/Activity;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {p1, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_2

    sget-object p1, Lcom/igexin/push/core/g;->a:Ljava/lang/String;

    :cond_0
    :goto_0
    if-eqz v0, :cond_3

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->c:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->d:Ljava/lang/String;

    invoke-virtual {v0, v1, v3, p1, p4}, Lcom/igexin/push/core/a/e;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    if-eqz p2, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->getPackageName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v0}, Landroid/content/pm/PackageManager;->getLaunchIntentForPackage(Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    invoke-virtual {v1, v0}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    :cond_1
    :goto_1
    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->b:Lcom/igexin/push/core/bean/PushTaskBean;

    const-string v2, "10030"

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;)V

    return-void

    :cond_2
    sget-object v3, Lcom/igexin/push/core/g;->a:Ljava/lang/String;

    invoke-virtual {v3, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    move v0, v1

    goto :goto_0

    :cond_3
    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->c:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->d:Ljava/lang/String;

    invoke-virtual {v0, v1, v3, p1, p4}, Lcom/igexin/push/core/a/e;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    if-eqz p2, :cond_1

    invoke-static {p3}, Lcom/igexin/push/extension/distribution/basic/util/c;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {v2, p3}, Landroid/content/pm/PackageManager;->getLaunchIntentForPackage(Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v1, v0}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    goto :goto_1
.end method

.method public startweb(Ljava/lang/String;Z)V
    .locals 3
    .annotation runtime Landroid/webkit/JavascriptInterface;
    .end annotation

    if-eqz p2, :cond_0

    const-string v0, "?"

    invoke-virtual {p1, v0}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v0

    if-lez v0, :cond_1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "&cid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    :cond_0
    :goto_0
    :try_start_0
    new-instance v0, Landroid/content/Intent;

    invoke-direct {v0}, Landroid/content/Intent;-><init>()V

    const-string v1, "android.intent.action.VIEW"

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    const/high16 v1, 0x10000000

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setFlags(I)Landroid/content/Intent;

    invoke-static {p1}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v1

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a:Landroid/app/Activity;

    invoke-virtual {v1, v0}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_1
    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->b:Lcom/igexin/push/core/bean/PushTaskBean;

    const-string v2, "10040"

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/core/a/e;->a(Lcom/igexin/push/core/bean/PushTaskBean;Ljava/lang/String;)V

    return-void

    :cond_1
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?cid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_1
.end method
