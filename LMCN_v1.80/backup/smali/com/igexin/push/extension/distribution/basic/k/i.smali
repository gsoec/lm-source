.class public Lcom/igexin/push/extension/distribution/basic/k/i;
.super Lcom/igexin/push/core/d/a;


# instance fields
.field private d:Landroid/webkit/WebView;

.field private e:Lcom/igexin/push/core/bean/PushTaskBean;

.field private f:Lcom/igexin/push/extension/distribution/basic/b/o;


# direct methods
.method public constructor <init>(Lcom/igexin/push/core/bean/PushTaskBean;Lcom/igexin/push/extension/distribution/basic/b/o;)V
    .locals 2

    invoke-direct {p0}, Lcom/igexin/push/core/d/a;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->e:Lcom/igexin/push/core/bean/PushTaskBean;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->f:Lcom/igexin/push/extension/distribution/basic/b/o;

    const-wide/32 v0, 0xa98ac7

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/k/i;->a(Ljava/lang/Long;)V

    invoke-virtual {p1}, Lcom/igexin/push/core/bean/PushTaskBean;->getTaskId()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/k/i;->a(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic a(Lcom/igexin/push/extension/distribution/basic/k/i;)Landroid/webkit/WebView;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    return-object v0
.end method

.method private j()V
    .locals 5

    new-instance v0, Landroid/webkit/WebView;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    invoke-virtual {v1}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/webkit/WebView;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    const v1, 0x106000b

    invoke-virtual {v0, v1}, Landroid/webkit/WebView;->setBackgroundResource(I)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    invoke-virtual {v0, v1}, Landroid/app/Activity;->setContentView(Landroid/view/View;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    const/high16 v1, 0x2000000

    invoke-virtual {v0, v1}, Landroid/webkit/WebView;->setScrollBarStyle(I)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/k/j;

    invoke-direct {v1, p0}, Lcom/igexin/push/extension/distribution/basic/k/j;-><init>(Lcom/igexin/push/extension/distribution/basic/k/i;)V

    invoke-virtual {v0, v1}, Landroid/webkit/WebView;->setWebViewClient(Landroid/webkit/WebViewClient;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/k/k;

    invoke-direct {v1, p0}, Lcom/igexin/push/extension/distribution/basic/k/k;-><init>(Lcom/igexin/push/extension/distribution/basic/k/i;)V

    invoke-virtual {v0, v1}, Landroid/webkit/WebView;->setOnKeyListener(Landroid/view/View$OnKeyListener;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    invoke-virtual {v0}, Landroid/webkit/WebView;->getSettings()Landroid/webkit/WebSettings;

    move-result-object v0

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Landroid/webkit/WebSettings;->setJavaScriptEnabled(Z)V

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Landroid/webkit/WebSettings;->setSavePassword(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->f:Lcom/igexin/push/extension/distribution/basic/b/o;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/o;->a()Ljava/lang/String;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->f:Lcom/igexin/push/extension/distribution/basic/b/o;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/b/o;->b()Z

    move-result v1

    if-eqz v1, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->f:Lcom/igexin/push/extension/distribution/basic/b/o;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/o;->c()Ljava/lang/String;

    move-result-object v0

    :cond_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->e:Lcom/igexin/push/core/bean/PushTaskBean;

    invoke-direct {v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;-><init>(Landroid/app/Activity;Lcom/igexin/push/core/bean/PushTaskBean;)V

    const-string v3, "sdk"

    invoke-virtual {v1, v2, v3}, Landroid/webkit/WebView;->addJavascriptInterface(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->d:Landroid/webkit/WebView;

    invoke-virtual {v1, v0}, Landroid/webkit/WebView;->loadUrl(Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method public a(Landroid/content/Intent;)V
    .locals 0

    return-void
.end method

.method public a(Landroid/content/res/Configuration;)V
    .locals 0

    return-void
.end method

.method public a(ILandroid/view/KeyEvent;)Z
    .locals 1

    const/4 v0, 0x0

    return v0
.end method

.method public a(Landroid/view/Menu;)Z
    .locals 1

    const/4 v0, 0x0

    return v0
.end method

.method public c()V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/k/i;->j()V

    return-void
.end method

.method public d()V
    .locals 0

    return-void
.end method

.method public e()V
    .locals 0

    return-void
.end method

.method public f()V
    .locals 0

    return-void
.end method

.method public g()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->isFinishing()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/util/c;->b()Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->finish()V

    :cond_0
    return-void
.end method

.method public h()V
    .locals 0

    return-void
.end method

.method public i()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->isFinishing()Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/i;->b:Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->finish()V

    :cond_0
    return-void
.end method
