.class public Lcom/igg/android/wegamers/auth/AuthActivity;
.super Landroid/app/Activity;
.source "AuthActivity.java"


# instance fields
.field private btn_auth:Landroid/widget/Button;

.field private btn_cancel:Landroid/widget/Button;

.field private mAuthInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

.field protected mDlgWait:Landroid/app/ProgressDialog;

.field private mRet:I

.field private onClickListener:Landroid/view/View$OnClickListener;

.field private resIggId:Ljava/lang/String;

.field private tv_content:Landroid/widget/TextView;

.field private tv_igg_id:Landroid/widget/TextView;

.field private tv_label:Landroid/widget/TextView;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 19
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V

    .line 23
    const/4 v0, 0x0

    iput v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mRet:I

    .line 24
    new-instance v0, Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-direct {v0}, Lcom/igg/android/wegamers/auth/AuthInfo;-><init>()V

    iput-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mAuthInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    .line 106
    new-instance v0, Lcom/igg/android/wegamers/auth/AuthActivity$1;

    invoke-direct {v0, p0}, Lcom/igg/android/wegamers/auth/AuthActivity$1;-><init>(Lcom/igg/android/wegamers/auth/AuthActivity;)V

    iput-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->onClickListener:Landroid/view/View$OnClickListener;

    .line 19
    return-void
.end method

.method static synthetic access$0(Lcom/igg/android/wegamers/auth/AuthActivity;)Lcom/igg/android/wegamers/auth/AuthInfo;
    .locals 1

    .prologue
    .line 24
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mAuthInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    return-object v0
.end method

.method static synthetic access$1(Lcom/igg/android/wegamers/auth/AuthActivity;)I
    .locals 1

    .prologue
    .line 23
    iget v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mRet:I

    return v0
.end method

.method static synthetic access$2(Lcom/igg/android/wegamers/auth/AuthActivity;Lcom/igg/android/wegamers/auth/AuthInfo;)V
    .locals 0

    .prologue
    .line 24
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mAuthInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    return-void
.end method

.method static synthetic access$3(Lcom/igg/android/wegamers/auth/AuthActivity;I)V
    .locals 0

    .prologue
    .line 23
    iput p1, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mRet:I

    return-void
.end method

.method static synthetic access$4(Lcom/igg/android/wegamers/auth/AuthActivity;)Landroid/widget/TextView;
    .locals 1

    .prologue
    .line 26
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_igg_id:Landroid/widget/TextView;

    return-object v0
.end method

.method static synthetic access$5(Lcom/igg/android/wegamers/auth/AuthActivity;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 31
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->resIggId:Ljava/lang/String;

    return-object v0
.end method

.method private initData()V
    .locals 3

    .prologue
    .line 70
    new-instance v1, Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-direct {v1, p0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;-><init>(Lcom/igg/android/wegamers/auth/AuthActivity;)V

    invoke-static {v1}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->setAuthResponse(Lcom/igg/android/wegamers/auth/IAuthResponse;)V

    .line 99
    new-instance v0, Landroid/content/Intent;

    invoke-direct {v0}, Landroid/content/Intent;-><init>()V

    .line 100
    .local v0, "intent":Landroid/content/Intent;
    const-string v1, "com.igg.android.game.authreceiver"

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    .line 101
    const-string v1, "START_AUTH"

    const-string v2, "START_AUTH"

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 102
    invoke-virtual {p0, v0}, Lcom/igg/android/wegamers/auth/AuthActivity;->sendBroadcast(Landroid/content/Intent;)V

    .line 103
    return-void
.end method

.method private initView()V
    .locals 8

    .prologue
    .line 42
    sget v6, Lcom/igg/android/wegamers/auth/R$id;->tv_igg_id:I

    invoke-virtual {p0, v6}, Lcom/igg/android/wegamers/auth/AuthActivity;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/TextView;

    iput-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_igg_id:Landroid/widget/TextView;

    .line 43
    sget v6, Lcom/igg/android/wegamers/auth/R$id;->tv_label:I

    invoke-virtual {p0, v6}, Lcom/igg/android/wegamers/auth/AuthActivity;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/TextView;

    iput-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_label:Landroid/widget/TextView;

    .line 44
    sget v6, Lcom/igg/android/wegamers/auth/R$id;->tv_content:I

    invoke-virtual {p0, v6}, Lcom/igg/android/wegamers/auth/AuthActivity;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/TextView;

    iput-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_content:Landroid/widget/TextView;

    .line 45
    sget v6, Lcom/igg/android/wegamers/auth/R$id;->btn_auth:I

    invoke-virtual {p0, v6}, Lcom/igg/android/wegamers/auth/AuthActivity;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/Button;

    iput-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->btn_auth:Landroid/widget/Button;

    .line 46
    sget v6, Lcom/igg/android/wegamers/auth/R$id;->btn_cancel:I

    invoke-virtual {p0, v6}, Lcom/igg/android/wegamers/auth/AuthActivity;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/Button;

    iput-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->btn_cancel:Landroid/widget/Button;

    .line 47
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->btn_auth:Landroid/widget/Button;

    iget-object v7, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->onClickListener:Landroid/view/View$OnClickListener;

    invoke-virtual {v6, v7}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 48
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->btn_cancel:Landroid/widget/Button;

    iget-object v7, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->onClickListener:Landroid/view/View$OnClickListener;

    invoke-virtual {v6, v7}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 50
    invoke-virtual {p0}, Lcom/igg/android/wegamers/auth/AuthActivity;->getIntent()Landroid/content/Intent;

    move-result-object v0

    .line 51
    .local v0, "intent":Landroid/content/Intent;
    const-string v6, "RES_IGG_ID"

    invoke-virtual {v0, v6}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    iput-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->resIggId:Ljava/lang/String;

    .line 52
    const-string v6, "RES_AUTH_LABEL"

    invoke-virtual {v0, v6}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 53
    .local v3, "resAuthLabel":Ljava/lang/String;
    const-string v6, "RES_AUTH_CONTENT"

    invoke-virtual {v0, v6}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 54
    .local v2, "resAuthContent":Ljava/lang/String;
    const-string v6, "RES_AUTH_BUTTON"

    invoke-virtual {v0, v6}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 55
    .local v1, "resAuthButton":Ljava/lang/String;
    const-string v6, "RES_AUTH_WAITTING"

    invoke-virtual {v0, v6}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 56
    .local v5, "resAuthwaitting":Ljava/lang/String;
    const-string v6, "RES_AUTH_CANCEL"

    invoke-virtual {v0, v6}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 59
    .local v4, "resAuthcancel":Ljava/lang/String;
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_igg_id:Landroid/widget/TextView;

    iget-object v7, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->resIggId:Ljava/lang/String;

    invoke-virtual {v6, v7}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 60
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_label:Landroid/widget/TextView;

    invoke-virtual {v6, v3}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 61
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->tv_content:Landroid/widget/TextView;

    invoke-virtual {v6, v2}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 62
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->btn_auth:Landroid/widget/Button;

    invoke-virtual {v6, v1}, Landroid/widget/Button;->setText(Ljava/lang/CharSequence;)V

    .line 63
    iget-object v6, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->btn_cancel:Landroid/widget/Button;

    invoke-virtual {v6, v4}, Landroid/widget/Button;->setText(Ljava/lang/CharSequence;)V

    .line 65
    const/4 v6, 0x1

    invoke-virtual {p0, v5, v6}, Lcom/igg/android/wegamers/auth/AuthActivity;->showWaitDlg(Ljava/lang/String;Z)V

    .line 66
    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 1
    .param p1, "savedInstanceState"    # Landroid/os/Bundle;

    .prologue
    .line 35
    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    .line 36
    sget v0, Lcom/igg/android/wegamers/auth/R$layout;->activity_auth:I

    invoke-virtual {p0, v0}, Lcom/igg/android/wegamers/auth/AuthActivity;->setContentView(I)V

    .line 37
    invoke-direct {p0}, Lcom/igg/android/wegamers/auth/AuthActivity;->initView()V

    .line 38
    invoke-direct {p0}, Lcom/igg/android/wegamers/auth/AuthActivity;->initData()V

    .line 39
    return-void
.end method

.method public onKeyDown(ILandroid/view/KeyEvent;)Z
    .locals 2
    .param p1, "keyCode"    # I
    .param p2, "event"    # Landroid/view/KeyEvent;

    .prologue
    .line 130
    const/4 v0, 0x4

    if-ne p1, v0, :cond_0

    .line 131
    invoke-virtual {p2}, Landroid/view/KeyEvent;->getAction()I

    move-result v0

    if-nez v0, :cond_0

    .line 132
    const/4 v0, -0x1

    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mAuthInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-static {p0, v0, v1}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->sendAuthInfo(Landroid/content/Context;ILcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 133
    invoke-virtual {p0}, Lcom/igg/android/wegamers/auth/AuthActivity;->finish()V

    .line 134
    const/4 v0, 0x1

    .line 137
    :goto_0
    return v0

    :cond_0
    invoke-super {p0, p1, p2}, Landroid/app/Activity;->onKeyDown(ILandroid/view/KeyEvent;)Z

    move-result v0

    goto :goto_0
.end method

.method public showWaitDlg(Ljava/lang/String;Z)V
    .locals 2
    .param p1, "strMsg"    # Ljava/lang/String;
    .param p2, "bShow"    # Z

    .prologue
    .line 141
    if-eqz p2, :cond_2

    invoke-virtual {p0}, Lcom/igg/android/wegamers/auth/AuthActivity;->isFinishing()Z

    move-result v0

    if-nez v0, :cond_2

    .line 142
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    if-nez v0, :cond_0

    .line 143
    new-instance v0, Landroid/app/ProgressDialog;

    invoke-direct {v0, p0}, Landroid/app/ProgressDialog;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    .line 145
    :cond_0
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    invoke-virtual {v0, p1}, Landroid/app/ProgressDialog;->setMessage(Ljava/lang/CharSequence;)V

    .line 146
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Landroid/app/ProgressDialog;->setCancelable(Z)V

    .line 147
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Landroid/app/ProgressDialog;->setCanceledOnTouchOutside(Z)V

    .line 148
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    invoke-virtual {v0}, Landroid/app/ProgressDialog;->show()V

    .line 155
    :cond_1
    :goto_0
    return-void

    .line 151
    :cond_2
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    if-eqz v0, :cond_1

    .line 152
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity;->mDlgWait:Landroid/app/ProgressDialog;

    invoke-virtual {v0}, Landroid/app/ProgressDialog;->dismiss()V

    goto :goto_0
.end method
