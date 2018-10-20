.class Lcom/igg/iggsdkbusiness/InputActivity$2;
.super Ljava/lang/Object;
.source "InputActivity.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/InputActivity;->ShowDiaog([I)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/InputActivity;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/InputActivity;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/InputActivity;

    .prologue
    .line 195
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 3
    .param p1, "arg0"    # Landroid/view/View;

    .prologue
    .line 198
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/InputActivity;->InputStrCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v1, v2}, Lcom/igg/iggsdkbusiness/InputActivity;->access$000(Lcom/igg/iggsdkbusiness/InputActivity;Ljava/lang/String;Ljava/lang/String;)V

    .line 200
    const-string v0, "InputActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "getText = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 201
    const-string v0, "InputActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "getText Len= "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 202
    const-string v0, "InputActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "toCharArray = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/String;->toCharArray()[C

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 203
    const-string v0, "InputActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "getBytes = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 205
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$2;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/InputActivity;->dialog:Landroid/app/Dialog;

    invoke-virtual {v0}, Landroid/app/Dialog;->hide()V

    .line 206
    return-void
.end method
