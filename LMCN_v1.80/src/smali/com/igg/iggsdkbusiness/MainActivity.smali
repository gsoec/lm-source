.class public Lcom/igg/iggsdkbusiness/MainActivity;
.super Landroid/app/Activity;
.source "MainActivity.java"


# instance fields
.field bButton:Landroid/widget/Button;

.field layoutParams:Landroid/widget/LinearLayout$LayoutParams;

.field layoutParamsButton:Landroid/widget/LinearLayout$LayoutParams;

.field linearLayout:Landroid/widget/LinearLayout;

.field mContext:Lcom/igg/iggsdkbusiness/MainActivity;

.field mWebview:Landroid/webkit/WebView;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 13
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V

    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/MainActivity;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/MainActivity;

    .prologue
    .line 13
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/MainActivity;->onResume()V

    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 4
    .param p1, "savedInstanceState"    # Landroid/os/Bundle;

    .prologue
    const/4 v3, -0x2

    .line 23
    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    .line 24
    iput-object p0, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mContext:Lcom/igg/iggsdkbusiness/MainActivity;

    .line 25
    new-instance v1, Landroid/widget/LinearLayout;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mContext:Lcom/igg/iggsdkbusiness/MainActivity;

    invoke-direct {v1, v2}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    .line 26
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    const/4 v2, 0x1

    invoke-virtual {v1, v2}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 27
    new-instance v1, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v1, v3, v3}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->layoutParamsButton:Landroid/widget/LinearLayout$LayoutParams;

    .line 28
    new-instance v1, Landroid/widget/Button;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mContext:Lcom/igg/iggsdkbusiness/MainActivity;

    invoke-direct {v1, v2}, Landroid/widget/Button;-><init>(Landroid/content/Context;)V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->bButton:Landroid/widget/Button;

    .line 29
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->bButton:Landroid/widget/Button;

    const-string v2, "Exit"

    invoke-virtual {v1, v2}, Landroid/widget/Button;->setText(Ljava/lang/CharSequence;)V

    .line 30
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->bButton:Landroid/widget/Button;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->layoutParamsButton:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v1, v2}, Landroid/widget/Button;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 31
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->bButton:Landroid/widget/Button;

    invoke-virtual {v1, v2}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 33
    new-instance v1, Landroid/widget/LinearLayout$LayoutParams;

    const/4 v2, -0x1

    invoke-direct {v1, v2, v3}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 34
    new-instance v1, Landroid/webkit/WebView;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mContext:Lcom/igg/iggsdkbusiness/MainActivity;

    invoke-direct {v1, v2}, Landroid/webkit/WebView;-><init>(Landroid/content/Context;)V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    .line 35
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v1, v2}, Landroid/webkit/WebView;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 36
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v1, v2}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 38
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v1}, Landroid/webkit/WebView;->getSettings()Landroid/webkit/WebSettings;

    move-result-object v1

    const/4 v2, 0x0

    invoke-virtual {v1, v2}, Landroid/webkit/WebSettings;->setJavaScriptEnabled(Z)V

    .line 40
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mContext:Lcom/igg/iggsdkbusiness/MainActivity;

    .line 42
    .local v0, "activity":Landroid/app/Activity;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    new-instance v2, Lcom/igg/iggsdkbusiness/MainActivity$1;

    invoke-direct {v2, p0, v0}, Lcom/igg/iggsdkbusiness/MainActivity$1;-><init>(Lcom/igg/iggsdkbusiness/MainActivity;Landroid/app/Activity;)V

    invoke-virtual {v1, v2}, Landroid/webkit/WebView;->setWebViewClient(Landroid/webkit/WebViewClient;)V

    .line 48
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    const-string v2, "http://www.google.com"

    invoke-virtual {v1, v2}, Landroid/webkit/WebView;->loadUrl(Ljava/lang/String;)V

    .line 49
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    invoke-virtual {p0, v1}, Lcom/igg/iggsdkbusiness/MainActivity;->setContentView(Landroid/view/View;)V

    .line 50
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity;->bButton:Landroid/widget/Button;

    new-instance v2, Lcom/igg/iggsdkbusiness/MainActivity$2;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/MainActivity$2;-><init>(Lcom/igg/iggsdkbusiness/MainActivity;)V

    invoke-virtual {v1, v2}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 60
    return-void
.end method
